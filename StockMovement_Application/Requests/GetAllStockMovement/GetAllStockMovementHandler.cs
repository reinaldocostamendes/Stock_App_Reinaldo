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

namespace StockMovement_Application.Requests.GetAllStockMovement
{
    public class GetAllStockMovementHandler : IRequestHandler<GetAllStockMovement, IEnumerable<StockMovement>>
    {
        #region Injections

        private readonly IMapper _mapper;
        private readonly IStockMovementRepository _stockMovementRepository;

        #endregion Injections

        #region Controller

        public GetAllStockMovementHandler(IMapper mapper, IStockMovementRepository stockMovementRepository)
        {
            _mapper = mapper;
            _stockMovementRepository = stockMovementRepository;
        }

        #endregion Controller

        public async Task<IEnumerable<StockMovement>> Handle(GetAllStockMovement request, CancellationToken cancellationToken)
        {
            var stockMovements = await _stockMovementRepository.GetAllStockMovement(request.pageParameters);

            return stockMovements;
        }
    }
}