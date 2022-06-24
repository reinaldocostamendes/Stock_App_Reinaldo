using AutoMapper;
using StockMovement_Domain.Enums;
using StockMovement_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Dtos
{
    public class StockMovementProductDTO
    {
        public Guid ProductId { get; set; }
        public string ProductDescription { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitValue { get; set; }
        public Guid StorageId { get; set; }
        public string StorageDescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StockMovementProductDTO, StockMovementProduct>().ReverseMap();
        }
    }
}