using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerType : AggregateRoot<FertilizerTypeId>
    {
        public FertilizerTypeId Id { get; }
        public FertilizerTypeName Name { get; }
        public FertilizerTypeDescription Description { get; }

        public ICollection<Fertilizer> Fertilizers { get; }

        public FertilizerType(FertilizerTypeName name, FertilizerTypeDescription description)
        {
            Id = new FertilizerTypeId(Guid.NewGuid());
            Name = name;
            Description = description;

            Fertilizers = new HashSet<Fertilizer>();
        }

        public void AddFertilizer(Fertilizer fertilizer)
        {
            Fertilizers.Add(fertilizer);
        }
    }
}
