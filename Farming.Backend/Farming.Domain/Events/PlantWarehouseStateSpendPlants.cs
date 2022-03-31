using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PlantWarehouseStateSpendPlants(PlantWarehouseState PlantWarehouseState, 
        PlantActionQuantity PlantActionQuantity) : IDomainEvent;
}
