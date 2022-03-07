
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerReadModel
    {
        public Guid Id { get; set; }
        public Guid FertilizerTypeId { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public FertilizerTypeReadModel FertilizerType { get; set; }
        public ICollection<PlantReadModel> SuitablePlants { get; set; }
    }
}
