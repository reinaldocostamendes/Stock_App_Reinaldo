using MediatR;
using StockMovement_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Requests.GetAllStockMovement
{
    public class GetAllStockMovement : IRequest<IEnumerable<StockMovement>>
    {
        public Infrastructure.Entity.PageParameters pageParameters { get; set; }
    }
}