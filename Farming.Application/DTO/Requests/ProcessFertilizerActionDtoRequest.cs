
namespace Farming.Application.DTO.Requests
{
    public class ProcessFertilizerActionDtoRequest
    {
        public Guid LandId { get; set; }
        public Guid UserId { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid FertilizerWarehouseId { get; set; }
        public decimal Quantity { get; set; }
    }
}
