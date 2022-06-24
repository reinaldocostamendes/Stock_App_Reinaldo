using Infrastructure.Entity;
using MediatR;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Dasheboard
{
    public class GetBestSellers : IRequest<IEnumerable<StockMovementProduct>>
    {
        public PageParameters PageParameters { get; set; }
    }
}