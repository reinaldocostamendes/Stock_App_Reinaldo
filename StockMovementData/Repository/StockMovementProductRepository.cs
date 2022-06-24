using Infrastructure.Entity;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using StockMovement_Domain.Enums;
using StockMovement_Domain.Models;
using StockMovementData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementData.Repository.Interface
{
    public class StockMovementProductRepository : RepositoryBase<StockMovementProduct>, IStockMovementProductRepository
    {
        private readonly StockMovementContext context;

        public StockMovementProductRepository(StockMovementContext context) : base(context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(Guid productId)
        {
            var product = await base.GetById(productId);

            await Delete(product);
        }

        public async Task<List<StockMovementProduct>> GetAllProducts(Infrastructure.Entity.PageParameters pg)
        {
            if (pg == null)
            {
                pg = new PageParameters() { PageIndex = 1, PageSize = 5 };
            }
            return await GetAll(pg);
        }

        public async Task<List<StockMovementProduct>> GetBestSellers(PageParameters pg)
        {
            var bestSalersProducts = await context.StockMovementProducts.
                Where(p => p.ProductType == ProductType.OUTPUT).OrderByDescending(x => x.Quantity)
                .OrderByDescending(x => x.UnitValue).AsNoTracking()
            .Skip(0)
            .Take(pg.PageSize).ToListAsync();
            return bestSalersProducts;
        }

        public async Task<StockMovementProduct> GetByIdAndStorageID(Guid productId, Guid storageId)
        {
            return await context.StockMovementProducts.Where(p =>
            p.ProductId == productId && p.StockMovementId == storageId).FirstOrDefaultAsync();
        }

        public async Task<StockMovementProduct> PostAsync(StockMovementProduct product)
        {
            await Post(product);
            return product;
        }

        public async Task<StockMovementProduct> PutAsync(StockMovementProduct product)
        {
            await Put(product);
            return product;
        }
    }
}