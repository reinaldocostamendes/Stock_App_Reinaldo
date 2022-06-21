using AutoMapper;
using MediatR;
using StockMovement_Data.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockMovement_Application.Requests.GetStockMovementById
{
    public class GetStockMovementByIdHandler : IRequestHandler<GetStockMovementById, StockMovement>
    {
        private readonly IMapper _mapper;
        private readonly IStockMovementRepository _stockMovementRepository;

        public GetStockMovementByIdHandler(IMapper mapper, IStockMovementRepository stockMovementRepository)
        {
            _mapper = mapper;
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<StockMovement> Handle(GetStockMovementById stockRequest,
            CancellationToken cancellationToken)
        {
            return await _stockMovementRepository.GetStockMovementById(stockRequest.StockMovementId);
        }
    }
}