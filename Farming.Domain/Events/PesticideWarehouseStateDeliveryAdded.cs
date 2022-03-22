using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PesticideWarehouseStateDeliveryAdded(PesticideWarehouseState PesticideWarehouseState,
        PesticideWarehouseDelivery PesticideWarehouseDelivery) : IDomainEvent;
}
