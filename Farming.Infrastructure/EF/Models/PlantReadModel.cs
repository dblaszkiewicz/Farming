
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
    }
}
