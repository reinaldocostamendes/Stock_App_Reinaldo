using MediatR;
using StockMovement_Application.Dtos;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Products.GetByProductIdAndStorageId
{
    public class GetByProductIdAndStorageId : IRequest<StockMovementProduct>
    {
        public Guid ProductId { get; set; }
        public Guid StorageId { get; set; }
    }
}