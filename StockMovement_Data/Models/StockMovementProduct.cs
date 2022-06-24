using Newtonsoft.Json;
using StockMovement_Data.Models;
using StockMovement_Domain.Enums;
using StockMovement_Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Domain.Models
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

        [JsonIgnore]
        public virtual StockMovement StockMovement { get; set; }

        public override bool IsValid()
        {
            if (ValidationResult == null)
            {
                var validator = new StockMovementProductValidation();
                ValidationResult = validator.Validate(this);
            }
            return ValidationResult?.IsValid != false;
        }
    }
}