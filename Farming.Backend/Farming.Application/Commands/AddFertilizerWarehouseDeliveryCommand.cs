using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class AddFertilizerWarehouseDeliveryCommand : IRequest<Response<AddFertilizerWarehouseDeliveryResponse>>
    {
        public Guid FertilizerWarehouseId { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

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
