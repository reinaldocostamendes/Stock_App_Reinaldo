using MediatR;
using StockMovement_Application.Dtos;
using StockMovement_Data.Enums;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Commands.Create.StockMoviment
{
    public class CreateStockMovementCommand : IRequest<StockMovementDTO>
    {
        public Guid OriginId { get; set; }
        public StockOrigin Origin { get; set; }

        public StockType Type { get; set; }
        public DateTime Date { get; set; }

        public List<StockMovementProduct> Products { get; set; }
    }
}