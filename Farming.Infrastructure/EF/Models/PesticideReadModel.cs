
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideReadModel
    {
        public Guid Id { get; set; }
        public Guid PesticideTypeId { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public PesticideTypeReadModel PesticideType { get; set; }
        public ICollection<PlantReadModel> SuitablePlants { get; set; }
    }
}
