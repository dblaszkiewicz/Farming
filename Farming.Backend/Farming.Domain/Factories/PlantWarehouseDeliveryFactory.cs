using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Factories
{
    public class PlantWarehouseDeliveryFactory : IPlantWarehouseDeliveryFactory
    {
        public PlantWarehouseDelivery Create(PlantId plantId, UserId userId, PlantWarehouseDeliveryQuantity quantity, PlantWarehouseDeliveryPrice price)
        {
            var realizationDate = new PlantWarehouseDeliveryRealizationDate();

            return new PlantWarehouseDelivery(plantId, userId, quantity, price, realizationDate);
        }
    }
}
