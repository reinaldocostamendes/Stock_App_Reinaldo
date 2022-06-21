using StockDomain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDomain.Models
{
    public class StockMovementProduct : Infrastructure.Entity.EntityBase<StockMovementProduct>
    {
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitValue { get; set; }

        [ForeignKey("StockMovement")]
        public Guid StockMovementId { get; set; }

        public string StorageDescription { get; set; }

        // public virtual StockMovement StockMovement { get; set; }
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}