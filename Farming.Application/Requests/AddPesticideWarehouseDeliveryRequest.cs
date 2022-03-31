namespace Farming.Application.Requests
{
    public class AddPesticideWarehouseDeliveryRequest
    {
        public Guid PesticideWarehouseId { get; set; }
        public Guid PesticideId { get; set; }
        public Guid UserId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
