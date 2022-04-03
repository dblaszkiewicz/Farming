using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Factories
{
    public interface IPesticideWarehouseDeliveryFactory
    {
        PesticideWarehouseDelivery Create(PesticideId pesticideId, UserId userId,
            PesticideWarehouseDeliveryQuantity quantity, PesticideWarehouseDeliveryPrice price);
    }
}
