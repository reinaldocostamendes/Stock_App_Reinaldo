using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RabbitMessageConsume;
using Stock_Application.Requests.Dasheboard;
using Stock_Application.Requests.Products.GetAll;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Application.Mapping;
using StockMovement_Application.Service;
using StockMovement_Application.Service.Interface;
using StockMovementData.Context;
using StockMovementData.Repository;
using StockMovementData.Repository.Interface;
using StockRabbitMQPublisher.StockPublisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Stock_Movement_Api
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stock_Movement_Api", Version = "v1" });
            });
            services.AddDbContext<StockMovementContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddStockPublisherConfiguration(Configuration);

            services.AddScoped<IStockMovementRepository, StockMovementRepsoitory>();
            services.AddScoped<IStockMovementProductRepository, StockMovementProductRepository>();
            services.AddHostedService<ConsumerMQ>();
            // services.AddMediatR(typeof(StartUp));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddOptions();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock_Movement_Api v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}