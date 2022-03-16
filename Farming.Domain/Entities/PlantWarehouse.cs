using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantWarehouse : AggregateRoot<PlantWarehouseId>
    {
        public PlantWarehouseId Id { get; }
        public PlantId PlantId { get; }
        public PlantWarehouseQuantity Quantity { get; }

        public Plant Plant { get; }
        public ICollection<PlantWarehouseDelivery> PlantWarehouseDeliveries { get; }
    }
}
