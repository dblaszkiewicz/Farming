namespace Farming.Application.Requests
{
    public class AddPesticideActionRequest
    {
        public Guid LandId { get; set; }
        public Guid PesticideId { get; set; }
        public Guid PesticideWarehouseId { get; set; }
        public decimal Quantity { get; set; }
    }
}
