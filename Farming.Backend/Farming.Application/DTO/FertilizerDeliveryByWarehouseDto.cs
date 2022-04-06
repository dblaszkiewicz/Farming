
namespace Farming.Application.DTO
{
    public class FertilizerDeliveryByWarehouseDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerTon { get; set; }
        public DateTimeOffset RealizationDate { get; set; }
    }
}
