
namespace Farming.Application.DTO
{
    public class PlantStateDto
    {
        public Guid PlantId { get; set; }
        public string PlantName { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public decimal EnoughForArea { get; set; }
    }
}
