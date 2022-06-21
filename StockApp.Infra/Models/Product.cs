using StockApp.Infra.Models.Base;
using StockApp.Infra.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Models
{
    public class Product : EntityBase<Product>
    {
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public Guid StorageId { get; set; }
        public string StorageDescription { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}