using AutoMapper;
using MediatR;
using StockMovement_Domain.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Dasheboard
{
    public class GetBestSellersHandlers : IRequestHandler<GetBestSellers, IEnumerable<StockMovementProduct>>
    {
        #region Injections

        private readonly IMapper _mapper;
        private readonly IStockMovementProductRepository _stockRepository;

        #endregion Injections

        #region Controller

        public GetBestSellersHandlers(IMapper mapper, IStockMovementProductRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        #endregion Controller

        public async Task<IEnumerable<StockMovementProduct>> Handle(GetBestSellers request, CancellationToken cancellationToken)
        {
            var products = await _stockRepository.GetBestSellers(request.PageParameters);

            return products;
        }
    }
}