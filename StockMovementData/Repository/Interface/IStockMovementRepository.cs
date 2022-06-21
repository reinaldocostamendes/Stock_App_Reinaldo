using StockMovement_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementData.Repository.Interface
{
    public interface IStockMovementRepository
    {
        public Task<StockMovement> PostAsync(StockMovement stockMovement);

        public Task<StockMovement> PutAsync(StockMovement stockMovement);

        public Task DeleteStockMovementById(Guid Id);

        public Task<StockMovement> GetStockMovementById(Guid Id);

        public Task<List<StockMovement>> GetAllStockMovement(Infrastructure.Entity.PageParameters ps);
    }
}