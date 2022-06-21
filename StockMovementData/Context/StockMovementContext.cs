using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using StockMovement_Data.Models;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementData.Context
{
    public class StockMovementContext : DataContext
    {
        public StockMovementContext(DbContextOptions<StockMovementContext> options) : base(options)
        {
        }

        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<StockMovementProduct> StockMovementProducts { get; set; }
    }
}