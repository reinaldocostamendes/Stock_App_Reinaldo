using MediatR;
using StockMovement_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Requests.GetStockMovementById
{
    public class GetStockMovementById : IRequest<StockMovement>
    {
        public Guid StockMovementId { get; set; }
    }
}