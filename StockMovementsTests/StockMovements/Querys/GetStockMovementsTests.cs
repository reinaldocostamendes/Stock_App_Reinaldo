using AutoMapper;
using Moq;
using Shouldly;
using StockMovement_Application.Common.AutoMapper;
using StockMovement_Application.Dtos;
using StockMovement_Application.Requests.GetAllStockMovement;
using StockMovement_Application.Requests.GetStockMovementById;
using StockMovement_Data.Models;
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
    public class GetStockMovementsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStockMovementRepository> _mockRepo;

        public GetStockMovementsTests()
        {
            _mockRepo = new Mock<IStockMovementRepository>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAllStockMovmentHandlerTests()
        {
            var handler = new GetAllStockMovementHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetAllStockMovement(), CancellationToken.None);

            result.ShouldBeOfType<List<StockMovement>>();

            result.ToList().Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GetStockMovmentByIdHandlerTests()
        {
            var handler = new GetStockMovementByIdHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetStockMovementById(), CancellationToken.None);

            result.ShouldBeOfType<List<StockMovement>>();

            // result.ToList().Count.ShouldBeGreaterThan(0);
        }
    }
}