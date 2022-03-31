
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }

        public ICollection<FertilizerReadModel> SuitableFertilizers { get; set; }
        public ICollection<PesticideReadModel> SuitablePesticides { get; set; }
        public ICollection<PlantActionReadModel> PlantActions { get; set; }
        public ICollection<PlantWarehouseDeliveryReadModel> PlantWarehouseDeliveries { get; set; }
        public ICollection<PlantWarehouseStateReadModel> PlantWarehouseStates { get; set; }
    }
}
