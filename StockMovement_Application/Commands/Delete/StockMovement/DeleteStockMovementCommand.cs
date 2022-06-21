using MediatR;
using StockMovement_Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Commands.Delete.StockMovement
{
    public class DeleteStockMovementCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}