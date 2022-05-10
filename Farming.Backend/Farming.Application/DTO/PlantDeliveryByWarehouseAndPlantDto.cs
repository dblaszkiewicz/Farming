
namespace Farming.Application.DTO
{
    public class PlantDeliveryByWarehouseAndPlantDto
    {
        public IEnumerable<PlantDeliveryDto> Deliveries { get; set; }
        public string Name { get; set; }
    }

    public class PlantDeliveryDto
    {
        public string UserName { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset RealizationDate { get; set; }
    }
}
