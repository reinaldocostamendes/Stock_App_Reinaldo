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
                OriginId = request.OriginId,
                Origin = request.Origin,
                Type = request.Type,
                Date = request.Date,
                Products = request.Products
            };

            await _stockMovementRepository.PostAsync(stockMovement);
            //   await _dataContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<StockMovementDTO>(stockMovement);
        }
    }
}