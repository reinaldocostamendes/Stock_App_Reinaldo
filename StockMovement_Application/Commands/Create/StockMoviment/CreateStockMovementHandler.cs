using AutoMapper;
using MediatR;
using StockMovement_Application.Dtos;
using StockMovement_Data.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockMovement_Application.Commands.Create.StockMoviment
{
    public class CreateStockMovementHandler : IRequestHandler<CreateStockMovementCommand, StockMovementDTO>
    {
        #region Injections

        private readonly IMapper _mapper;
        private readonly IStockMovementRepository _stockMovementRepository;

        #endregion Injections

        #region Constructor

        public CreateStockMovementHandler(IMapper mapper, IStockMovementRepository stockMovementRepository)
        {
            _mapper = mapper;
            _stockMovementRepository = stockMovementRepository;
        }

        #endregion Constructor

        public async Task<StockMovementDTO> Handle(CreateStockMovementCommand request, CancellationToken cancellationToken)
        {
            var stockMovement = new StockMovement()
            {
                Id = Guid.NewGuid(),
                OriginId = request.OriginId,
                Origin = request.Origin,
                Type = request.Type,
                Date = request.Date,
                Products = request.Products
            };
            if (!stockMovement.IsValid())
            {
                var message = stockMovement.
                    ValidationResult.Errors.
                    ConvertAll(x => x.ErrorMessage.ToString()).ToList();

                throw new Exception(ErrorList(message));
            }
            else
            {
                await _stockMovementRepository.PostAsync(stockMovement);
            }

            return _mapper.Map<StockMovementDTO>(stockMovement);
        }

        private String ErrorList(List<string> message)
        {
            var string_errors = "[ ";
            foreach (var error in message)
            {
                string_errors += " - " + error.ToString();
            }
            return string_errors + " ]";
        }
    }
}