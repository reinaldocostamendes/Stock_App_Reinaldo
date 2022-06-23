using AutoMapper;
using MediatR;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerRabbitMQStock
{
    public class ConsumerMessageRabbitMQStock : IHostedService
    {
        private readonly IMapper _mapper;
        private readonly IRequestHandler<CreateStockMovementCommand, StockMovementDTO> _requestHandler;

        public ConsumerMessageRabbitMQStock(IMapper mapper, IRequestHandler<CreateStockMovementCommand, StockMovementDTO> requestHandler)
        {
            _mapper = mapper;
            _requestHandler = requestHandler;
        }

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
                HostName = "rabbitmq2"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            while (true)
            {
                channel.ExchangeDeclare(exchange: "stocks", type: "stocks");
                channel.QueueDeclare("stocks", exclusive: false);
                channel.QueueBind(queue: "stocks",
             exchange: "stocks", routingKey: "anonymous.info");
                var consumer = new EventingBasicConsumer(channel);
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

                channel.BasicConsume(queue: "stocks", autoAck: true, consumer: consumer);
            }
        }
    }
}