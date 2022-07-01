using Infrastructure.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_Application.Requests.Products.GetAll;
using Stock_Application.Requests.Products.GetByProductId;
using Stock_Application.Requests.Products.GetByProductIdAndStorageId;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Movement_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IRequestHandler<GetAllProducts,
            IEnumerable<StockMovementProduct>> _requestHandler;

        private readonly IRequestHandler<GetByProductId,
            StockMovementProduct> _requestHandlerById;

        private readonly IRequestHandler<GetByProductIdAndStorageId,
            StockMovementProduct> _requestHandlerByIdAndStorageId;

        public StockController(IRequestHandler<GetAllProducts,
            IEnumerable<StockMovementProduct>> requestHandler,
            IRequestHandler<GetByProductId, StockMovementProduct> requestHandlerById,
            IRequestHandler<GetByProductIdAndStorageId,
                StockMovementProduct> requestHandlerByIdAndStorageId)
        {
            _requestHandler = requestHandler;
            _requestHandlerById = requestHandlerById;
            _requestHandlerByIdAndStorageId = requestHandlerByIdAndStorageId;
        }

        [HttpGet("Products")]
        public async Task<IEnumerable<StockMovementProduct>> GetAll([FromQuery] PageParameters pageParameters)
        {
            await Task.CompletedTask;
            GetAllProducts getallProducts = new GetAllProducts();
            getallProducts.pageParameters = pageParameters;
            return await _requestHandler.Handle(getallProducts, new CancellationToken());
        }

        [HttpGet("Product/{ProductId}")]
        public async Task<ActionResult<StockMovementProduct>> GetByProductId(Guid ProductId)
        {
            GetByProductId productById = new GetByProductId();
            productById.ProductId = ProductId;
            var product = await _requestHandlerById.Handle(productById, new CancellationToken());
            if (product == null)
            {
                return NoContent();
            }
            return product;
        }

        [HttpGet("Product/{ProductId}/storage/{StorageId}")]
        public async Task<ActionResult<StockMovementProduct>> GetByProductIdAndStorageId(Guid ProductId, Guid StorageId)
        {
            GetByProductIdAndStorageId productByIdAndStorage = new GetByProductIdAndStorageId();
            productByIdAndStorage.ProductId = ProductId;
            productByIdAndStorage.StorageId = StorageId;
            var product = await _requestHandlerByIdAndStorageId
                .Handle(productByIdAndStorage, new CancellationToken());
            if (product == null)
            {
                return NoContent();
            }
            return product;
        }
    }
}