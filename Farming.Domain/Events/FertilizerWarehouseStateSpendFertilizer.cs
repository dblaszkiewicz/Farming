using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record FertilizerWarehouseStateSpendFertilizer(FertilizerWarehouseState FertilizerWarehouseState,
        FertilizerActionQuantity FertilizerActionQuantity) : IDomainEvent;
}
