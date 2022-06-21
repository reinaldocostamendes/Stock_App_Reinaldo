using FluentValidation;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Products.GetByProductIdAndStorageId
{
    public class GetProductByProductIdAndStockValidation : AbstractValidator<GetByProductIdAndStorageId>
    {
        protected readonly DataContext _dataContext;

        public GetProductByProductIdAndStockValidation(DataContext dataContext)
        {
            _dataContext = dataContext;

            //RuleFor(x => x.ProductId)
            //    .MustAsync(ProductNotFound)
            //    .WithMessage("Product not found.");

            //RuleFor(x => x.StorageId)
            //   .MustAsync(StorageNotFound)
            //   .WithMessage("Storage not found.");
        }

        //public async Task<bool> ProductNotFound(Guid productId, CancellationToken cancellationToken)
        //{
        //    var result = await _dataContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
        //    if (result != null)
        //        return true;

        //    return false;
        //}

        //public async Task<bool> StorageNotFound(Guid storageId, CancellationToken cancellationToken)
        //{
        //    var result = await _dataContext.Products.Where(p => p.ProductId == storageId).FirstOrDefaultAsync();
        //    if (result != null)
        //        return true;

        //    return false;
        //}
    }
}