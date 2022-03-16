using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record FertilizerWarehouseDeliveryAdded(FertilizerWarehouse FertilizerWarehouse,
        FertilizerWarehouseDelivery FertilizerWarehouseDelivery) : IDomainEvent;
}
