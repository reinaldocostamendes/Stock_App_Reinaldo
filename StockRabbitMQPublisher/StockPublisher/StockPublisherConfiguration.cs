using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockRabbitMQPublisher.StockPublisher
{
    public static class StockPublisherConfiguration
    {
        public static void AddStockPublisherConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStockPublisher, StockPublisher>();
        }
    }
}