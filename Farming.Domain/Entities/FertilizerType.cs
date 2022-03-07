using Farming.Domain.ValueObjects.Fertilizer;

namespace Farming.Domain.Entities
{
    public class FertilizerType
    {
        public FertilizerTypeId Id { get; }
        public string Name { get; }
        public string Description { get; }

        public ICollection<Fertilizer> Fertilizers { get; }
    }
}
