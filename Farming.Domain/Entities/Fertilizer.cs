using Farming.Domain.ValueObjects.Fertilizer;

namespace Farming.Domain.Entities
{
    public class Fertilizer
    {
        public FertilizerId Id { get; }
        public FertilizerTypeId FertilizerTypeId { get; }
        public FertilizerRequiredAmountPerHectare FertilizerRequiredAmountPerHectare { get; }
        public FertilizerName Name { get; }
        public FertilizerDescription Description { get; }

        public FertilizerType FertilizerType { get; }
        public ICollection<Plant> SuitablePlants { get; }
    }
}
