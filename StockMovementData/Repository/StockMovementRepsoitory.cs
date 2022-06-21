using Infrastructure.Context;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using StockMovement_Data.Models;
using StockMovementData.Context;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementData.Repository
{
    public class StockMovementRepsoitory : RepositoryBase<StockMovement>, IStockMovementRepository
    {
        private readonly StockMovementContext _context;

        public StockMovementRepsoitory(StockMovementContext context) : base(context)
        {
            _context = context;
            SetInclude(x => x.Include(p => p.Products));
        }

        public async Task<List<StockMovement>> GetAllStockMovement(Infrastructure.Entity.PageParameters pg)
        {
            return await GetAll(pg);
        }

        public async Task<StockMovement> GetStockMovementById(Guid Id)
        {
            return await _context.StockMovements.Include(p => p.Products).Where(s => s.Id == Id).FirstOrDefaultAsync();
        }

        public async Task DeleteStockMovementById(Guid Id)
        {
            var stockmovement = await base.GetById(Id);
            if (stockmovement != null)
            {
                await base.Delete(stockmovement);
            }
        }

        public async Task<StockMovement> PostAsync(StockMovement stockMovement)
        {
            await Post(stockMovement);
            return stockMovement;
        }

        public async Task<StockMovement> PutAsync(StockMovement stockMovement)
        {
            await Put(stockMovement);
            return stockMovement;
        }
    }
}