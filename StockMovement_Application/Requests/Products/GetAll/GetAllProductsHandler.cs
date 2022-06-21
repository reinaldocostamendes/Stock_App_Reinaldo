using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StockMovement_Domain.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Products.GetAll
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, IEnumerable<StockMovementProduct>>
    {
        #region Injections

        private readonly IMapper _mapper;
        private readonly IStockMovementProductRepository stockService;

        #endregion Injections

        #region Controller

        public GetAllProductsHandler(IMapper mapper, IStockMovementProductRepository stockService)
        {
            _mapper = mapper;
            this.stockService = stockService;
        }

        #endregion Controller

        public async Task<IEnumerable<StockMovementProduct>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var products = await stockService.GetAllProducts(request.pageParameters);

            return _mapper.Map<IEnumerable<StockMovementProduct>>(products);
        }
    }
}