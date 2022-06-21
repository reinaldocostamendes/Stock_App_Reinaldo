using AutoMapper;
using StockMovement_Application.Dtos;
using StockMovement_Application.Service.Interface;
using StockMovement_Data.Models;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMovement_Application.Service
{
    public class StockMevementService : IStockMevementService
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _imapper;

        public StockMevementService(IStockMovementRepository stockMovementRepository, IMapper imapper)
        {
            _stockMovementRepository = stockMovementRepository;
            _imapper = imapper;
        }

        public Task<List<StockMovement>> GetAllStockMovement(Infrastructure.Entity.PageParameters pg)
        {
            return _stockMovementRepository.GetAllStockMovement(pg);
        }

        public Task<StockMovement> GetStockMovementById(Guid Id)
        {
            return _stockMovementRepository.GetStockMovementById(Id);
        }

        public Task<StockMovement> PostAsync(StockMovementDTO stockMovementDTO)
        {
            return _stockMovementRepository.PostAsync(_imapper.Map<StockMovement>(stockMovementDTO));
        }

        public Task<StockMovement> PutAsync(StockMovementDTO stockMovementDTO)
        {
            return _stockMovementRepository.PutAsync(_imapper.Map<StockMovement>(stockMovementDTO));
        }
    }
}