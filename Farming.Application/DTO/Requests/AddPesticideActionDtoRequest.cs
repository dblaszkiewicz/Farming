
namespace Farming.Application.DTO.Requests
{
    public class AddPesticideActionDtoRequest
    {
        public Guid LandId { get; set; }
        public Guid UserId { get; set; }
        public Guid PesticideId { get; set; }
        public Guid PesticideWarehouseId { get; set; }
        public decimal Quantity { get; set; }
    }
}
