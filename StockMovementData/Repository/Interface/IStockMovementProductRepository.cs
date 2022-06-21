using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementData.Repository.Interface
{
    public interface IStockMovementProductRepository
    {
        public Task<StockMovementProduct> PostAsync(StockMovementProduct product);

        public Task<StockMovementProduct> GetById(Guid productId);

        public Task<StockMovementProduct> GetByIdAndStorageID(Guid productId, Guid storageId);

        public Task<List<StockMovementProduct>> GetAllProducts(Infrastructure.Entity.PageParameters pg);

        public Task<List<StockMovementProduct>> GetBestSellers();

        public Task<StockMovementProduct> PutAsync(StockMovementProduct product);

        public Task DeleteAsync(Guid productId);
    }
}