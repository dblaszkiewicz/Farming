using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Season;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class LandRealization : AggregateRoot<LandRealizationId>
    {
        public LandRealizationId Id { get; }
        public LandId LandId { get; }
        public SeasonId SeasonId { get; }

        public Land Land { get; }
        public Season Season { get; }
        public ICollection<PlantAction> PlantActions { get; }
        public ICollection<FertilizerAction> FertilizerActions { get; }
        public ICollection<PesticideAction> PesticideActions { get; }

        public LandRealization()
        {
            // for EF
        }

        public LandRealization(LandId landId)
        {
            Id = new LandRealizationId(Guid.NewGuid());
            LandId = landId;

            PlantActions = new HashSet<PlantAction>();
            FertilizerActions = new HashSet<FertilizerAction>();
            PesticideActions = new HashSet<PesticideAction>();
        }

        internal void AddPlantAction(PlantAction plantAction)
        {
            PlantActions.Add(plantAction);
            AddEvent(new PlantActionAdded(this, plantAction));
        }

        internal void AddFertilizerAction(FertilizerAction fertilizerAction)
        {
            FertilizerActions.Add(fertilizerAction);
            AddEvent(new FertilizerActionAdded(this, fertilizerAction));
        }
    }
}
