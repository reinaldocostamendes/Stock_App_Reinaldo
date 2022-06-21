using MediatR;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stock_Application.Commands.Stock.Create;
using Stock_Application.Dtos;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockConsumer.StockConsume
{
    public class StockRabbitMQConsumer : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            PullMessage();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task PullMessage()
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            while (true)
            {
                channel.QueueDeclare("stocks", exclusive: false);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    CreateProductCommand command = (CreateProductCommand)Newtonsoft.Json.JsonConvert.DeserializeObject<CreateProductCommand>(message);
                    Mediator.Send(command);
                };

                channel.BasicConsume(queue: "stocks", autoAck: true, consumer: consumer);
            }
        }
    }
}