
namespace Farming.Application.DTO
{
    public class PlantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public string Description { get; set; }
    }
}
