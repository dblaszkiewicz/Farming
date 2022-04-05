namespace Farming.Application.Requests
{
    public class AddFertilizerWarehouseDeliveryRequest
    {
        public Guid FertilizerWarehouseId { get; set; }
        public Guid FertilizerId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
