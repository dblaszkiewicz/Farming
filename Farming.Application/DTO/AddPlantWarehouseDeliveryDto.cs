
namespace Farming.Application.DTO
{
    public class AddPlantWarehouseDeliveryDto
    {
        public Guid PlantWarehouseId { get; set; }
        public Guid PlantId { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
