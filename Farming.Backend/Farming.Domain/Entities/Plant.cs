using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Plant : Tenant
    {
        public PlantId Id { get; }
        public PlantName Name { get; }
        public PlantRequiredAmountPerHectare RequiredAmountPerHectare { get; }
        public PlantDescription Description { get; }
        public PlantUnit Unit { get; }

        public ICollection<Fertilizer> SuitableFertilizers { get; }
        public ICollection<Pesticide> SuitablePesticides { get; }
        public ICollection<PlantAction> PlantActions { get; }
        public ICollection<PlantWarehouseDelivery> PlantWarehouseDeliveries { get; }
        public ICollection<PlantWarehouseState> PlantWarehouseStates { get; }
    }
}
