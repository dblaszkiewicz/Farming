namespace Farming.Application.DTO
{
    public class AddFertilizerWarehouseDeliveryDto
    {
        public Guid FertilizerWarehouseId { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
