
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantWarehouseReadModel
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public decimal Quantity { get; set; }

        public PlantReadModel Plant { get; set; }
        public ICollection<PlantWarehouseDeliveryReadModel> PlantWarehouseDeliveries { get; set; }
    }
}
