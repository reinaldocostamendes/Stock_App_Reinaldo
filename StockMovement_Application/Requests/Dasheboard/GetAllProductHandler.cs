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
    public class GetAllProductsHandler : IRequestHandler<GetBestSelers, IEnumerable<StockMovementProduct>>
    {
        #region Injections

        private readonly IMapper _mapper;
        private readonly IStockMovementProductRepository _stockRepository;

        #endregion Injections

        #region Controller

        public GetAllProductsHandler(IMapper mapper, IStockMovementProductRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        #endregion Controller

        public async Task<IEnumerable<StockMovementProduct>> Handle(GetBestSelers request, CancellationToken cancellationToken)
        {
            var products = await _stockRepository.GetAllProducts(request.pageParameters);

            return products;
        }
    }
}