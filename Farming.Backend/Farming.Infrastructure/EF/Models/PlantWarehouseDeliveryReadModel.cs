
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantWarehouseDeliveryReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public Guid PlantWarehouseStateId { get; set; }
        public Guid UserId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset RealizationDate { get; set; }

        public PlantReadModel Plant { get; set; }
        public UserReadModel User { get; set; }
        public PlantWarehouseStateReadModel PlantWarehouseState { get; set; }
    }
}
