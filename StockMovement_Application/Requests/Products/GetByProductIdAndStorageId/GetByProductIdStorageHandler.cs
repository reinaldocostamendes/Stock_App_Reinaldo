using AutoMapper;
using Infrastructure.Context;
using MediatR;
using StockMovement_Application.Dtos;
using StockMovement_Domain.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Products.GetByProductIdAndStorageId
{
    public class GetByProductIdStorageHandler :
        IRequestHandler<GetByProductIdAndStorageId, StockMovementProduct>
    {
        #region Injections

        private readonly IMapper _mapper;
        private readonly IStockMovementProductRepository _productRepository;

        #endregion Injections

        #region Controller

        public GetByProductIdStorageHandler(IMapper mapper,
            IStockMovementProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #endregion Controller

        public async Task<StockMovementProduct> Handle(GetByProductIdAndStorageId productRequest,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAndStorageID(productRequest.ProductId, productRequest.StorageId);

            return product;
        }
    }
}