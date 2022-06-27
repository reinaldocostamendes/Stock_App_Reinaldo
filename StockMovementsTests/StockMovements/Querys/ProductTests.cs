using AutoMapper;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Stock_Application.Requests.Products.GetByProductId;
using Stock_Application.Requests.Products.GetByProductIdAndStorageId;
using StockMovement_Application.Common.AutoMapper;
using StockMovement_Application.Dtos;
using StockMovement_Domain.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockMovementsTests.StockMovements.Querys
{
    public class ProductTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStockMovementProductRepository> _mockRepo;
        private readonly AutoMocker _mocker;

        public ProductTests()
        {
            _mockRepo = new Mock<IStockMovementProductRepository>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mocker = new AutoMocker();
        }

        [Fact]
        public async Task GetProductIdHandlerTests()
        {
            var _iStockProductRepository = _mocker.Get<IStockMovementProductRepository>();
            var handler = new GetByProductIdHandler(_mapper, _iStockProductRepository);
            GetByProductId getByProductId = new GetByProductId();
            getByProductId.ProductId = Guid.NewGuid();
            var result = await handler.Handle(getByProductId, CancellationToken.None);

            result.ShouldBeOfType<List<StockMovementProduct>>();
        }

        [Fact]
        public async Task GetProductIdAndStorageIdHandlerTests()
        {
            var _iStockProductRepository = _mocker.Get<IStockMovementProductRepository>();
            var handler = new GetByProductIdStorageHandler(_mapper, _iStockProductRepository);
            GetByProductIdAndStorageId getByProductIdAndStorageId = new GetByProductIdAndStorageId();
            getByProductIdAndStorageId.ProductId = Guid.NewGuid();
            getByProductIdAndStorageId.StorageId = Guid.NewGuid();
            var result = await handler.Handle(getByProductIdAndStorageId, CancellationToken.None);

            result.ShouldBeOfType<List<StockMovementProduct>>();

            // result.ToList().Count.ShouldBeGreaterThan(0);
        }
    }
}