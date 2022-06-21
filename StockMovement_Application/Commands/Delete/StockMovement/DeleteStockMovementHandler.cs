using MediatR;
using StockMovement_Application.Dtos;
using StockMovementData.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockMovement_Application.Commands.Delete.StockMovement
{
    public class DeleteStockMovementHandler : IRequestHandler<DeleteStockMovementCommand, bool>
    {
        private readonly IStockMovementRepository _stockMovementRepository;

        public DeleteStockMovementHandler(IStockMovementRepository stockMovementRepository)
        {
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<bool> Handle(DeleteStockMovementCommand request, CancellationToken cancellationToken)
        {
            await _stockMovementRepository.DeleteStockMovementById(request.Id);
            return true;
        }
    }
}