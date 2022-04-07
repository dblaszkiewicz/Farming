
namespace Farming.Application.DTO
{
    public class PesticideDeliveryByWarehouseAndPesticideDto
    {
        public IEnumerable<PesticideDeliveryDto> Deliveries { get; set; }
        public decimal AveragePricePerLiter { get; set; }
        public string Name { get; set; }
    }

    public class PesticideDeliveryDto
    {
        public string UserName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerLiter { get; set; }
        public DateTimeOffset RealizationDate { get; set; }
    }
}
