using Infrastructure.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Application.Commands.Delete.StockMovement;
using StockMovement_Application.Dtos;
using StockMovement_Application.Requests.GetAllStockMovement;
using StockMovement_Application.Requests.GetStockMovementById;
using StockMovement_Data.Models;
using StockRabbitMQPublisher.StockPublisher;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Movement_Api.Controllers
{
    [Route("api/StockMovements")]
    [ApiController]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockPublisher _rabbitMQPublisher;

        private readonly IRequestHandler<GetAllStockMovement,
            IEnumerable<StockMovement>> _getallrequestHandler;

        private readonly IRequestHandler<GetStockMovementById,
            StockMovement> _getByIdrequestHandler;

        private readonly IRequestHandler<DeleteStockMovementCommand,
            bool> _deleteRequestHandler;

        public StockMovementController(IStockPublisher rabbitMQPublisher,
            IRequestHandler<GetAllStockMovement,
                IEnumerable<StockMovement>> getallrequestHandler,
            IRequestHandler<GetStockMovementById, StockMovement> getByIdrequestHandler,
            IRequestHandler<DeleteStockMovementCommand,
            bool> deleteRequestHandler)
        {
            _rabbitMQPublisher = rabbitMQPublisher;
            _getallrequestHandler = getallrequestHandler;
            _getByIdrequestHandler = getByIdrequestHandler;
            _deleteRequestHandler = deleteRequestHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StockMovementDTO stockMovementDTO)
        {
            CreateStockMovementCommand command = new CreateStockMovementCommand()
            {
                OriginId = stockMovementDTO.OriginId,
                Origin = stockMovementDTO.Origin,

                Type = stockMovementDTO.Type,
                Date = stockMovementDTO.Date,
                Products = stockMovementDTO.Products
            };
            try
            {
                _rabbitMQPublisher.SendMessage(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(true);
        }

        [HttpGet]
        public async Task<IEnumerable<StockMovement>> GetAll([FromQuery] PageParameters pageParameters)
        {
            GetAllStockMovement getAllStockMovement = new GetAllStockMovement();
            getAllStockMovement.pageParameters = pageParameters;
            return await _getallrequestHandler.Handle(getAllStockMovement, new CancellationToken());
        }

        [HttpGet("StockMovementById")]
        public async Task<ActionResult<StockMovement>> GetStockMovementById(Guid id)
        {
            GetStockMovementById getById = new GetStockMovementById();
            getById.StockMovementId = id;
            return await _getByIdrequestHandler.Handle(getById, new CancellationToken());
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteStockMovement(Guid id)
        {
            DeleteStockMovementCommand deleteCommand = new DeleteStockMovementCommand();
            deleteCommand.Id = id;
            return await _deleteRequestHandler.Handle(deleteCommand, new CancellationToken());
        }
    }
}