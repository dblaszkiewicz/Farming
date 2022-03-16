using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Plant : AggregateRoot<PlantId>
    {
        public PlantId Id { get; }
        public PlantName Name { get; }
        public PlantRequiredAmountPerHectare RequiredAmountPerHectare { get; }
        public PlantDescription Description { get; }

        public ICollection<Fertilizer> SuitableFertilizers { get; }
    }
}
