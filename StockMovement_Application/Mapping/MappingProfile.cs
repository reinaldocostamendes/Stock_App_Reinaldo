using AutoMapper;
using StockMovement_Application.Dtos;
using StockMovement_Data.Models;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockMovement, StockMovementDTO>().ReverseMap();
            CreateMap<StockMovementProduct, StockMovementProductDTO>().ReverseMap();
        }
    }
}