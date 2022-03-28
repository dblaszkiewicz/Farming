
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantWarehouseStateReadModel
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public Guid PlantWarehouseId { get; set; }
        public decimal Quantity { get; set; }

        public PlantReadModel Plant { get; }
        public PlantWarehouseReadModel PlantWarehouse { get; }
        public ICollection<PlantWarehouseDeliveryReadModel> PlantWarehouseDeliveries { get; }
    }
}
