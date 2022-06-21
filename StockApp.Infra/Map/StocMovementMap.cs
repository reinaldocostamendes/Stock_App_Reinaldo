using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockApp.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Map
{
    public class StocMovementMap : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable("StockMovement");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OriginId);
            builder.Property(x => x.Origin);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Date).IsRequired();
        }
    }
}