using AutoMapper;
using MediatR;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Application.Dtos;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer
{
    public class MessageConsumer : IHostedService
    {
        private readonly IMapper _mapper;
        private readonly IRequestHandler<CreateStockMovementCommand, StockMovementDTO> _requestHandler;

        public MessageConsumer(IMapper mapper, IRequestHandler<CreateStockMovementCommand, StockMovementDTO> requestHandler)
        {
            _mapper = mapper;
            _requestHandler = requestHandler;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            consome();
            PullMessage();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void consome()
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq2"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("stocks_movements", exclusive: false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Message received: {message}");
            };

            channel.BasicConsume(queue: "stocks_movements", autoAck: true, consumer: consumer);

            Console.ReadKey();
        }

        public Task PullMessage()
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq2"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            //  channel.ExchangeDeclare(exchange: "stocks_movements", type: "topic");
            channel.QueueDeclare("stocks_movements", exclusive: false);
            //  channel.QueueBind(queue: "stocks_movements", exchange: "stocks_movements", routingKey: "stocks_movements");
            var consumer = new EventingBasicConsumer(channel);
            while (true)
            {
                consumer.Received += async (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    CreateStockMovementCommand command = (CreateStockMovementCommand)Newtonsoft
                     .Json.JsonConvert.DeserializeObject<CreateStockMovementCommand>(message);
                    //ProductDTO productDTO = (ProductDTO)Newtonsoft
                    //.Json.JsonConvert.DeserializeObject<ProductDTO>(message);
                    //await stockRepository.PostAsync(mapper.Map<Product>(productDTO));
                    await _requestHandler.Handle(command, new CancellationToken());

                    // await Mediator.Send(command,new CancellationToken());
                };

                channel.BasicConsume(queue: "stocks_movements", autoAck: true, consumer: consumer);
            }
        }
    }
}