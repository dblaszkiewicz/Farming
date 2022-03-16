using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantWarehouseState : AggregateRoot<PlantWarehouseStateId>
    {
        public PlantWarehouseStateId Id { get; }
        public PlantId PlantId { get; }
        public PlantWarehouseId PlantWarehouseId { get; }
        public PlantWarehouseQuantity PlantWarehouseQuantity { get; }

        public Plant Plant { get; }
        public PlantWarehouse PlantWarehouse { get; }
        public ICollection<PlantWarehouseDelivery> PlantWarehouseDeliveries { get; set; }
    }
}
