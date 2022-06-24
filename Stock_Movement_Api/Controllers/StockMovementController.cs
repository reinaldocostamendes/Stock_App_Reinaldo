using AutoMapper;
using Infrastructure.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Application.Commands.Delete.StockMovement;
using StockMovement_Application.Dtos;
using StockMovement_Application.Requests.GetAllStockMovement;
using StockMovement_Application.Requests.GetStockMovementById;
using StockMovement_Data.Models;
using StockMovement_Domain.Models;
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
        private readonly IMediator mediator;
        private readonly IMapper _mapper;

        public StockMovementController(IStockPublisher rabbitMQPublisher, IServiceProvider serviceProvider, IMapper mapper)
        {
            _mapper = mapper;
            _rabbitMQPublisher = rabbitMQPublisher;
            var scope = serviceProvider.CreateScope();
            mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
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
                Products = stockMovementDTO.Products.ConvertAll(p => _mapper.Map<StockMovementProduct>(p))
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
            return await mediator.Send(getAllStockMovement);
        }

        [HttpGet("StockMovementById")]
        public async Task<ActionResult<StockMovement>> GetStockMovementById(Guid id)
        {
            GetStockMovementById getById = new GetStockMovementById();
            getById.StockMovementId = id;
            return await mediator.Send(getById);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteStockMovement(Guid id)
        {
            DeleteStockMovementCommand deleteCommand = new DeleteStockMovementCommand();
            deleteCommand.Id = id;
            return await mediator.Send(deleteCommand);
        }
    }
}