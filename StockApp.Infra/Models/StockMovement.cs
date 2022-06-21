using StockApp.Infra.Models.Base;
using StockApp.Infra.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Models
{
    public class StockMovement : EntityBase<StockMovement>
    {
        public Guid OriginId { get; set; }
        public StockOrigin Origin { get; set; }

        public StockType Type { get; set; }
        public DateTime Date { get; set; }

        public List<Product> Products { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}