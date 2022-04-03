using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Land;
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
        public ICollection<Pesticide> SuitablePesticides { get; }
        public ICollection<PlantAction> PlantActions { get; }
        public ICollection<PlantWarehouseDelivery> PlantWarehouseDeliveries { get; }
        public ICollection<PlantWarehouseState> PlantWarehouseStates { get; }

        public Plant(PlantName name, PlantRequiredAmountPerHectare requiredAmountPerHectare, PlantDescription description)
        {
            Id = new PlantId(Guid.NewGuid());
            Name = name;
            RequiredAmountPerHectare = requiredAmountPerHectare;
            Description = description;
        }

        public bool IsEnoughPlantForWholeArea(LandArea area, PlantActionQuantity quantity)
        {
            if (area * RequiredAmountPerHectare >= quantity)
            {
                return true;
            }

            return false;
        }
    }
}
