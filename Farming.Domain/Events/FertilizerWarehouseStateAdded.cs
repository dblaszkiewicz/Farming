using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record FertilizerWarehouseStateAdded(FertilizerWarehouse FertilizerWarehouse,
        FertilizerWarehouseState FertilizerWarehouseState) : IDomainEvent;
}
