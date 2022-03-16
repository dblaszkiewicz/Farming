using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class AddFertilizerWarehouseDeliveryCommand : IRequest<Response<AddFertilizerWarehouseDeliveryResponse>>
    {
        public Guid FertilizerWarehouseId { get; }
        public Guid FertilizerId { get; }
        public Guid UserId { get; }
        public decimal Price { get; }
        public decimal Quantity { get; }

        public AddFertilizerWarehouseDeliveryCommand(Guid fertilizerWarehouseId, Guid fertilizerId, Guid userId, decimal price, decimal quantity)
        {
            FertilizerWarehouseId = fertilizerWarehouseId;
            FertilizerId = fertilizerId;
            UserId = userId;
            Price = price;
            Quantity = quantity;
        }
    }
}
