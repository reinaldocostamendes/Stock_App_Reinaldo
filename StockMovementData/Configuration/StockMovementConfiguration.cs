using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMovement_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementData.Configuration
{
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OriginId);
            builder.Property(x => x.Origin);
            builder.Property(x => x.Type);
            builder.Property(x => x.Date);
            builder.HasMany(x => x.Products).
                WithOne(m => m.StockMovement)
                .HasForeignKey(f => f.StockMovementId);
        }
    }
}