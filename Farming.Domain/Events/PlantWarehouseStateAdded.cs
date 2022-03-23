using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PlantWarehouseStateAdded(PlantWarehouse PlantWarehouse, 
        PlantWarehouseState PlantWarehouseState) : IDomainEvent;
}
