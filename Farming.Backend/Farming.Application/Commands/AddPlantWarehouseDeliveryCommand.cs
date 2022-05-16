using Farming.Application.Commands.Responses;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands
{
    public class AddPlantWarehouseDeliveryCommand : IRequest<Response<AddPlantWarehouseDeliveryResponse>>
    {
        public Guid PlantWarehouseId { get; set; }
        public Guid PlantId { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public AddPlantWarehouseDeliveryCommand(Guid plantWarehouseId, Guid plantId, Guid userId, decimal price, decimal quantity)
        {
            PlantWarehouseId = plantWarehouseId;
            PlantId = plantId;
            UserId = userId;
            Price = price;
            Quantity = quantity;
        }
    }
}
