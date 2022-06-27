using Infrastructure.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Stock_Application.Requests.Dasheboard;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock_Movement_Api.Controllers
{
    [Route("api/DasheBoard")]
    [ApiController]
    public class DasheBoardController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IServiceProvider _serviceProvider;

        public DasheBoardController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            var scope = _serviceProvider.CreateScope();
            mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        }

        [HttpGet("Products")]
        public async Task<IEnumerable<StockMovementProduct>> GetAll([FromQuery] PageParameters pageParameters)
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            getAllProducts.pageParameters = pageParameters;
            return await mediator.Send(getAllProducts);
        }

        [HttpGet("Product/BestSelers")]
        public async Task<IEnumerable<StockMovementProduct>> GetBestSelersProducts()
        {
            PageParameters pg = new PageParameters()
            {
                PageIndex = 1,
                PageSize = 5
            };
            GetBestSellers getBestSelers = new GetBestSellers();
            getBestSelers.PageParameters = pg;

            return await mediator.Send(getBestSelers);
        }
    }
}