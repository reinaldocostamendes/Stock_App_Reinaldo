using AutoMapper;
using Moq;
using Shouldly;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Application.Dtos;
using StockMovement_Application.Mapping;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockMovementsTests.StockMovements.Commands
{
    public class CreateStockMovementHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IStockMovementRepository> _mockUow;
        private readonly CreateStockMovementHandler _handler;

        public CreateStockMovementHandlerTests()
        {
            _mockUow = new Mock<IStockMovementRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _handler = new CreateStockMovementHandler(_mapper, _mockUow.Object);
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var command = StockCommandFaker.Generate();
            var result = await _handler.Handle(command, CancellationToken.None);

            var listStock = await _mockUow.Object.GetAllStockMovement(new Infrastructure.Entity.PageParameters()
            {
                PageIndex = 1,
                PageSize = 5
            });

            result.ShouldBeOfType<StockMovementDTO>();
        }

        [Fact]
        public async Task InValid_LeaveType_Added()
        {
            var command = StockCommandFaker.GenerateInvlaid();
            var result = await _handler.Handle(command, CancellationToken.None);

            var listStock = await _mockUow.Object.GetAllStockMovement(new Infrastructure.Entity.PageParameters()
            {
                PageIndex = 1,
                PageSize = 5
            });

            result.ShouldBeOfType<StockMovementDTO>();
        }
    }
}