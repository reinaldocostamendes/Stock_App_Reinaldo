using MediatR;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Application.Requests.Dasheboard
{
    public class GetBestSelers : IRequest<IEnumerable<StockMovementProduct>>
    {
        public Infrastructure.Entity.PageParameters pageParameters { get; set; }
    }
}