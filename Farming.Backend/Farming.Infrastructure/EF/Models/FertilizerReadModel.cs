

namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public Guid FertilizerTypeId { get; set; }
        public decimal RequiredAmountPerHectare { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public FertilizerTypeReadModel FertilizerType { get; set; }
        public ICollection<PlantReadModel> SuitablePlants { get; set; }
        public ICollection<FertilizerWarehouseDeliveryReadModel> FertilizerWarehouseDeliveries { get; set; }
        public ICollection<FertilizerWarehouseStateReadModel> FertilizerWarehouseStates { get; set; }
        public ICollection<FertilizerActionReadModel> FertilizerActions { get; set; }

        public FertilizerReadModel()
        {

        }

        internal FertilizerReadModel(string name, string description, decimal requiredAmountPerHectare, List<PlantReadModel> suitablePlants)
        {
            Id = Guid.NewGuid();
            SuitablePlants = suitablePlants;
            Name = name;
            Description = description;
            RequiredAmountPerHectare = requiredAmountPerHectare;

            FertilizerWarehouseDeliveries = new HashSet<FertilizerWarehouseDeliveryReadModel>();
            FertilizerWarehouseStates = new HashSet<FertilizerWarehouseStateReadModel>();
            FertilizerActions = new HashSet<FertilizerActionReadModel>();
        }
    }
}
