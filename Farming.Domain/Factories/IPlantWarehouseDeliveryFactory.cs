using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public interface IPlantWarehouseDeliveryFactory
    {
        PlantWarehouseDelivery Create(PlantId plantId, UserId userId,
            PlantWarehouseDeliveryQuantity quantity, PlantWarehouseDeliveryPrice price);
    }
}
