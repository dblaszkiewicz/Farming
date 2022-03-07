using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Entities
{
    public class PlantWarehouse
    {
        public PlantWarehouseId Id { get; }
        public PlantId PlantId { get; }
        public PlantWarehouseQuantity Quantity { get; }

        public Plant Plant { get; }
        public ICollection<PlantWarehouseDelivery> PlantWarehouseDeliveries { get; }
    }
}
