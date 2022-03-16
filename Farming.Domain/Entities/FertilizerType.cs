using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerType : AggregateRoot<FertilizerTypeId>
    {
        public FertilizerTypeId Id { get; }
        public FertilizerTypeName Name { get; }
        public FertilizerTypeDescription Description { get; }

        public ICollection<Fertilizer> Fertilizers { get; }
    }
}
