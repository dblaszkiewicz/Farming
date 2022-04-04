
namespace Farming.Application.DTO
{
    public class FertilizerStateDto
    {
        public Guid FertilizerId { get; set; }
        public Guid FertilizerTypeId { get; set; }
        public string FertilizerName { get; set; }
        public string FertilizerTypeName { get; set; }
        public decimal Quantity { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public decimal EnoughForArea { get; set; }
    }
}
