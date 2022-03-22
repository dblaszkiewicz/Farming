using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public class PesticideWarehouseDeliveryFactory : IPesticideWarehouseDeliveryFactory
    {
        public PesticideWarehouseDelivery Create(PesticideWarehouseDeliveryId deliveryId, PesticideId pesticideId, UserId userId, PesticideWarehouseDeliveryQuantity quantity, PesticideWarehouseDeliveryPrice price)
        {
            var realizationDate = new PesticideWarehouseDeliveryRealizationDate();

            return new PesticideWarehouseDelivery(deliveryId, pesticideId, userId, quantity, price, realizationDate);
        }
    }
}
