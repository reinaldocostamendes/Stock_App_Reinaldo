using StockMovement_Application.Dtos;
using StockMovement_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Service.Interface
{
    public interface IStockMevementService
    {
        public Task<StockMovement> PostAsync(StockMovementDTO stockMovementDTO);

        public Task<StockMovement> PutAsync(StockMovementDTO stockMovementDTO);

        public Task<StockMovement> GetStockMovementById(Guid Id);

        public Task<List<StockMovement>> GetAllStockMovement(Infrastructure.Entity.PageParameters pg);
    }
}