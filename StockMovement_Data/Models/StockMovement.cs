using StockMovement_Data.Enums;
using StockMovement_Domain.Models;
using StockMovement_Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Data.Models
{
    public class StockMovement : Infrastructure.Entity.EntityBase<StockMovement>
    {
        public Guid OriginId { get; set; }
        public StockOrigin Origin { get; set; }

        public StockType Type { get; set; }
        public DateTime Date { get; set; }

        public List<StockMovementProduct> Products { get; set; }

        public override bool IsValid()
        {
            if (ValidationResult == null)
            {
                var validator = new StockMovementValidation();
                ValidationResult = validator.Validate(this);
            }
            return ValidationResult?.IsValid != false;
        }
    }
}