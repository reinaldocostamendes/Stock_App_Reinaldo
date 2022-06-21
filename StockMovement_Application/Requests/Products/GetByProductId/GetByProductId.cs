using MediatR;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Products.GetByProductId
{
    public class GetByProductId : IRequest<StockMovementProduct>
    {
        public Guid ProductId { get; set; }
    }
}