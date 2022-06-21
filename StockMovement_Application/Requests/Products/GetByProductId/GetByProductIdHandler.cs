using AutoMapper;
using Infrastructure.Context;
using MediatR;
using StockMovement_Domain.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Products.GetByProductId
{
    public class GetByProductIdHandler : IRequestHandler<GetByProductId, StockMovementProduct>
    {
        private readonly IMapper _mapper;
        private readonly IStockMovementProductRepository _productRepository;

        public GetByProductIdHandler(IMapper mapper, IStockMovementProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<StockMovementProduct> Handle(GetByProductId productRequest,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(productRequest.ProductId);
        }
    }
}