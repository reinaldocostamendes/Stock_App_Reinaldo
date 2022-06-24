using AutoMapper;
using StockMovement_Application.Common.AutoMapper;
using StockMovement_Data.Enums;
using StockMovement_Data.Models;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Dtos
{
    public class StockMovementDTO : IMap<StockMovement>
    {
        public Guid OriginId { get; set; }
        public StockOrigin Origin { get; set; }

        public StockType Type { get; set; }
        public DateTime Date { get; set; }

        public List<StockMovementProductDTO> Products { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StockMovementDTO, StockMovement>().ReverseMap();
        }
    }
}