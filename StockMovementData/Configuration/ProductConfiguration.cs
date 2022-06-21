using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovementData.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<StockMovementProduct>
    {
        public void Configure(EntityTypeBuilder<StockMovementProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.ProductDescription).IsRequired();
            builder.Property(x => x.ProductType).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitValue).IsRequired();
            builder.Property(x => x.StockMovementId).IsRequired();
            builder.Property(x => x.StorageDescription).IsRequired();
        }
    }
}