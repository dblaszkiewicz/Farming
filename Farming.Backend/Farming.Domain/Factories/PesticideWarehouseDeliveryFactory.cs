using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Factories
{
    public class PesticideWarehouseDeliveryFactory : IPesticideWarehouseDeliveryFactory
    {
        public PesticideWarehouseDelivery Create(PesticideId pesticideId, UserId userId, PesticideWarehouseDeliveryQuantity quantity, PesticideWarehouseDeliveryPrice price)
        {
            var realizationDate = new PesticideWarehouseDeliveryRealizationDate();

            return new PesticideWarehouseDelivery(pesticideId, userId, quantity, price, realizationDate);
        }
    }
}
