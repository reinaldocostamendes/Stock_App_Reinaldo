using FluentValidation;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Domain.Validations
{
    public class StockMovementProductValidation : AbstractValidator<StockMovementProduct>
    {
        public StockMovementProductValidation()
        {
            RuleFor(d => d.Id).NotNull().WithMessage("Id is requirid");
            RuleFor(d => d.ProductId).NotNull().WithMessage("ProductId is requirid");
            RuleFor(d => d.ProductDescription).NotNull().WithMessage("ProductDescription is requirid");
            RuleFor(d => d.ProductType).NotNull().WithMessage("Product type is requirid");
            RuleFor(d => d.Quantity).NotNull().WithMessage("Quantity is requirid");
            RuleFor(d => d.UnitValue).NotNull().WithMessage("UnitValue is requirid");
            // RuleFor(d => d.StockMovementId.NotNull().WithMessage("PaymentDate is requirid");
            RuleFor(d => d.StorageDescription).NotNull().WithMessage("StorageDescription is requirid");
        }
    }
}