using FluentValidation;
using StockMovementData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Commands.Create.StockMoviment
{
    public class StockMovementCreateValidator : AbstractValidator<CreateStockMovementCommand>
    {
        protected readonly StockMovementContext _dataContext;

        public StockMovementCreateValidator(StockMovementContext dataContext)
        {
            _dataContext = dataContext;

            RuleFor(x => x.Type).NotNull()
              .NotEmpty()
              .WithMessage("StockMovement Type is required.");

            RuleFor(x => x.Date).NotNull()
              .NotEmpty()
              .WithMessage("Date is required.");
        }
    }
}