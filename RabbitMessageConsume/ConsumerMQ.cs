using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Application.Dtos;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMessageConsume
{
    public class ConsumerMQ : IHostedService
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public ConsumerMQ(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var scope = _serviceProvider.CreateScope();
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Thread(PullMessage).Start();
            // PullMessage();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void PullMessage()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("stocks_movements", exclusive: false);
            var consumer = new EventingBasicConsumer(channel);
            while (true)
            {
                consumer.Received += async (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    CreateStockMovementCommand command = (CreateStockMovementCommand)Newtonsoft
                     .Json.JsonConvert.DeserializeObject<CreateStockMovementCommand>(message);

                    await _mediator.Send(command);
                };

                channel.BasicConsume(queue: "stocks_movements", autoAck: true, consumer: consumer);
                Thread.Sleep(1000000000);
            }
        }
    }
}