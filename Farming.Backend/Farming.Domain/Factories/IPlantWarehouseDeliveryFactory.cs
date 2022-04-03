using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Factories
{
    public interface IPlantWarehouseDeliveryFactory
    {
        PlantWarehouseDelivery Create(PlantId plantId, UserId userId,
            PlantWarehouseDeliveryQuantity quantity, PlantWarehouseDeliveryPrice price);
    }
}
