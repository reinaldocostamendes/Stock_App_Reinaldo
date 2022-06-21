using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using StockDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Data.Context
{
    public class StockContext : DataContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {
        }

        public DbSet<StockMovementProduct> Products { get; set; }
    }
}