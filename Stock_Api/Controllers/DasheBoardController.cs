using Infrastructure.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_Application.Requests.Dasheboard;
using Stock_Application.Requests.Products.GetAll;
using StockMovement_Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stock_Api.Controllers
{
    [Route("api/DasheBoard")]
    [ApiController]
    public class DasheBoardController : ControllerBase
    {
        private readonly IRequestHandler<GetAllProducts,
            IEnumerable<StockMovementProduct>> _requestHandler;

        private readonly IRequestHandler<GetBestSelers,
           IEnumerable<StockMovementProduct>> _requestHandlerBestSelers;

        [HttpGet("Products")]
        public async Task<IEnumerable<StockMovementProduct>> GetAll([FromQuery] PageParameters pageParameters)
        {
            GetAllProducts getAllProducts = new GetAllProducts();
            getAllProducts.pageParameters = pageParameters;
            return await _requestHandler.Handle(getAllProducts, new System.Threading.CancellationToken());
        }

        [HttpGet("BestSelers")]
        public async Task<IEnumerable<StockMovementProduct>> GetBestSelers()
        {
            GetBestSelers getBestSelers = new GetBestSelers();

            return await _requestHandlerBestSelers.Handle(getBestSelers, new System.Threading.CancellationToken());
        }
    }
}