using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public class FertilizerWarehouseDeliveryFactory : IFertilizerWarehouseDeliveryFactory
    {
        public FertilizerWarehouseDelivery Create(FertilizerWarehouseDeliveryId deliveryId, FertilizerId fertilizerId, UserId userId, FertilizerWarehouseDeliveryQuantity quantity, 
            FertilizerWarehouseDeliveryPrice price)
        {
            var realizationDate = new FertilizerWarehouseDeliveryRealizationDate();

            return new FertilizerWarehouseDelivery(deliveryId, fertilizerId, userId, quantity, price, realizationDate);
        }
    }
}
