using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockApp.Infra.Models.Base
{
    public abstract class EntityBase<TEntity>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        #region Validation

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();

        #endregion Validation
    }
}