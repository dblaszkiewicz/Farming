using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PlantWarehouseStateDeliveryAdded(PlantWarehouseState PlantWarehouseState,
        PlantWarehouseDelivery PlantWarehouseDelivery) : IDomainEvent;
}
