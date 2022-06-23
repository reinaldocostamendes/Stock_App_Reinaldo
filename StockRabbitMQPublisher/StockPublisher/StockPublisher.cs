using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockRabbitMQPublisher.StockPublisher
{
    public class StockPublisher : IStockPublisher
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq2"
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            // channel.ExchangeDeclare(exchange: "stocks_movements", type: "topic");
            channel.QueueDeclare("stocks_movements", exclusive: false);
            //  channel.QueueBind(queue: "stocks_movements", exchange: "stocks_movements", routingKey: "stocks_movements");

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "stocks_movements", body: body);
        }
    }
}