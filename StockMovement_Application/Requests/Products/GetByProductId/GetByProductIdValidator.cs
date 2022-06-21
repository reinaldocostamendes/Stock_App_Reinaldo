using FluentValidation;
using Infrastructure.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Products.GetByProductId
{
    public class GetByProductIdValidator : AbstractValidator<GetByProductId>
    {
        protected readonly DataContext _dataContext;

        public GetByProductIdValidator(DataContext dataContext)
        {
            _dataContext = dataContext;

            //RuleFor(x => x.ProductId)
            //    .MustAsync(ProductNotFound)
            //    .WithMessage("Product not found.");
        }
    }
}