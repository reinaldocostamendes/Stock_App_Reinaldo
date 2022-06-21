using Microsoft.EntityFrameworkCore;
using StockApp.Infra.Map;
using StockApp.Infra.Models;
using StockApp.Infra.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StocMovementMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }
}