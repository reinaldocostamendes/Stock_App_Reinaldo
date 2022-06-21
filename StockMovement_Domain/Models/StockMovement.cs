using Infrastructure.Entity;
using Stock_Data.Models;
using StockMovement_Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Data.Models
{
    public class StockMovement : EntityBase<StockMovement>
    {
        public Guid OriginId { get; set; }
        public StockOrigin Origin { get; set; }

        public StockType Type { get; set; }
        public DateTime Date { get; set; }

        public List<Stock_Data.Models.Product> Products { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}