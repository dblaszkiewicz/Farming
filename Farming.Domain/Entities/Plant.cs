using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Entities
{
    public class Plant
    {
        public PlantId Id { get; }
        public PlantName Name { get; }
        public PlantRequiredAmountPerHectare RequiredAmountPerHectare { get; }
        public PlantDescription Description { get; }
    }
}
