using FluentValidation;
using StockMovement_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Domain.Validations
{
    public class StockMovementValidation : AbstractValidator<StockMovement>
    {
        public StockMovementValidation()
        {
            RuleFor(d => d.Id).NotNull().WithMessage("Id is requirid");
            RuleFor(d => d.OriginId).NotNull().WithMessage("OriginId is requirid");
            RuleFor(d => d.Origin).NotNull().WithMessage("Origin is requirid");
            RuleFor(d => d.Type).NotNull().WithMessage("Type is requirid");
            RuleFor(d => d.Date).NotNull().WithMessage("Date is requirid");
        }
    }
}