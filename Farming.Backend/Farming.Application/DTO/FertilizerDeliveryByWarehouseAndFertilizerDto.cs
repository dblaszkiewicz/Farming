namespace Farming.Application.DTO
{
    public class FertilizerDeliveryByWarehouseAndFertilizerDto
    {
        public IEnumerable<FertilizerDeliveryDto> Deliveries { get; set; }
        public decimal AveragePricePerTon { get; set; }
    }

    public class FertilizerDeliveryDto
    {
        public string UserName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PricePerTon { get; set; }
        public DateTimeOffset RealizationDate { get; set; }
    }
}
