using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerType : AggregateRoot<FertilizerTypeId>
    {
        public FertilizerTypeName Name { get; }
        public FertilizerTypeDescription Description { get; }

        public ICollection<Fertilizer> Fertilizers { get; }
    }
}
