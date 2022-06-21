using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockRabbitMQPublisher.StockPublisher
{
    public interface IStockPublisher
    {
        void SendMessage<T>(T message);
    }
}