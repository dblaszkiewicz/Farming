using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record FertilizerWarehouseStateDeliveryAdded(FertilizerWarehouseState FertilizerWarehouseState,
        FertilizerWarehouseDelivery FertilizerWarehouseDelivery) : IDomainEvent;
}
