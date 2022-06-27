using AutoMapper;
using Moq;
using Moq.AutoMock;
using Shouldly;
using Stock_Application.Requests.Dasheboard;
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
    public class DasheBoardTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStockMovementProductRepository> _mockRepo;
        private readonly AutoMocker _mocker;

        public DasheBoardTests()
        {
            _mockRepo = new Mock<IStockMovementProductRepository>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mocker = new AutoMocker();
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductIdHandlerTests()
        {
            var _iStockProductRepository = _mocker.Get<IStockMovementProductRepository>();
            var handler = new GetAllProductsHandler(_mapper, _iStockProductRepository);

            var result = await handler.Handle(new GetAllProducts(), CancellationToken.None);

            result.ShouldBeOfType<IEnumerable<StockMovementProduct>>();
        }

        [Fact]
        public async Task GetBestSelersHandlerTests()
        {
            var _iStockProductRepository = _mocker.Get<IStockMovementProductRepository>();
            var handler = new GetBestSellersHandlers(_mapper, _iStockProductRepository);
            GetBestSellers bestSellers = new GetBestSellers();
            bestSellers.PageParameters = new Infrastructure.Entity.PageParameters()
            {
                PageIndex = 1,
                PageSize = 5
            };
            var result = await handler.Handle(bestSellers, CancellationToken.None);

            result.ShouldBeOfType<IEnumerable<StockMovementProduct>>();

            // result.ToList().Count.ShouldBeGreaterThan(0);
        }
    }
}