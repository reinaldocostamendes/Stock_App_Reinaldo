using Bogus;
using StockMovement_Application.Commands.Create.StockMoviment;
using StockMovement_Data.Enums;
using StockMovement_Domain.Enums;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementsTests
{
    public class StockCommandFaker
    {
        public static CreateStockMovementCommand Generate()
        {
            Faker<StockMovementProduct> prodReq = new Faker<StockMovementProduct>()
               .RuleFor(x => x.Id, Guid.NewGuid())
               .RuleFor(x => x.ProductId, Guid.NewGuid())
               .RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
               .RuleFor(x => x.ProductType, x => x.PickRandom<ProductType>())
               .RuleFor(x => x.Quantity, x => x.Random.Int(1, 10))
               .RuleFor(x => x.UnitValue, x => x.Random.Decimal(1, 100));

            CreateStockMovementCommand stockReq = new Faker<CreateStockMovementCommand>()

                     .RuleFor(x => x.OriginId, x => Guid.NewGuid())
                     .RuleFor(x => x.Origin, x => x.PickRandom<StockOrigin>())
                     .RuleFor(x => x.Type, x => x.PickRandom<StockType>())
                     .RuleFor(x => x.Date, x => DateTime.Now)
                     .RuleFor(x => x.Products, x => prodReq.GenerateBetween(1, 5));
            return stockReq;
        }

        public static CreateStockMovementCommand GenerateInvlaid()
        {
            Faker<StockMovementProduct> prodReq = new Faker<StockMovementProduct>()
               .RuleFor(x => x.Id, Guid.NewGuid())
               .RuleFor(x => x.ProductId, Guid.Empty)
               .RuleFor(x => x.ProductDescription, x => x.Random.String(1, 256))
               .RuleFor(x => x.ProductType, x => x.PickRandom<ProductType>())
               .RuleFor(x => x.Quantity, x => x.Random.Int(1, 10))
               .RuleFor(x => x.UnitValue, x => x.Random.Decimal(1, 100));

            CreateStockMovementCommand stockReq = new Faker<CreateStockMovementCommand>()

                     .RuleFor(x => x.OriginId, x => Guid.NewGuid())
                     .RuleFor(x => x.Origin, x => x.PickRandom<StockOrigin>())
                     .RuleFor(x => x.Type, x => x.PickRandom<StockType>())
                     .RuleFor(x => x.Date, x => DateTime.Now)
                     .RuleFor(x => x.Products, x => prodReq.GenerateBetween(1, 5));
            return stockReq;
        }
    }
}