using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class ProcessFertilizerActionCommand : IRequest<Response<ProcessFertilizerActionResponse>>
    {
        public Guid LandId { get; set; }
        public Guid UserId { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid FertilizerWarehouseId { get; set; }
        public decimal Quantity { get; set; }

        public ProcessFertilizerActionCommand(Guid landId, Guid userId, Guid fertilizerId, Guid fertilizerWarehouseId, decimal quantity)
        {
            LandId = landId;
            UserId = userId;
            FertilizerId = fertilizerId;
            FertilizerWarehouseId = fertilizerWarehouseId;
            Quantity = quantity;
        }
    }
}
