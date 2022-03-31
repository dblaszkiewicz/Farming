using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public interface IPesticideWarehouseDeliveryFactory
    {
        PesticideWarehouseDelivery Create(PesticideId pesticideId, UserId userId,
            PesticideWarehouseDeliveryQuantity quantity, PesticideWarehouseDeliveryPrice price);
    }
}
