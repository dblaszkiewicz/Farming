using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Pesticide : AggregateRoot<PesticideId>
    {
        public PesticideTypeId PesticideTypeId { get; }
        public PesticideRequiredAmountPerHectare RequiredAmountPerHectare { get; }
        public PesticideName Name { get; }
        public PesticideDescription Description { get; }

        public PesticideType PesticideType { get; }
        public ICollection<Plant> SuitablePlants { get; }
        public ICollection<PesticideAction> PesticideActions { get; }
        public ICollection<PesticideWarehouseDelivery> PesticideWarehouseDeliveries { get; }
        public ICollection<PesticideWarehouseState> PesticideWarehouseStates { get; }

        public Pesticide(PesticideRequiredAmountPerHectare requiredAmountPerHectare, PesticideName name, PesticideDescription description)
        {
            Id = new PesticideId(Guid.NewGuid());
            RequiredAmountPerHectare = requiredAmountPerHectare;
            Name = name;
            Description = description;

            SuitablePlants = new HashSet<Plant>();
            PesticideActions = new HashSet<PesticideAction>();
            PesticideWarehouseDeliveries = new HashSet<PesticideWarehouseDelivery>();
            PesticideWarehouseStates = new HashSet<PesticideWarehouseState>();
        }

        public void AddSutiablePlants(IEnumerable<Plant> plants)
        {
            foreach (var plant in plants)
            {
                SuitablePlants.Add(plant);
            }
            IncrementVersion();
        }

        public bool IsEnoughPesticideForWholeArea(LandArea area, PesticideActionQuantity quantity)
        {
            if (area * RequiredAmountPerHectare >= quantity)
            {
                return true;
            }

            return false;
        }
    }
}
