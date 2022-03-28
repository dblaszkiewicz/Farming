using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Season;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Season : AggregateRoot<SeasonId>
    {
        public SeasonId Id { get; }
        public SeasonActive Active { get; }
        public SeasonStartDate StartDate { get; }

        public ICollection<LandRealization> LandRealizations { get; }

        public Season()
        {
            Id = Guid.NewGuid();
            Active = new SeasonActive(true);
            StartDate = new SeasonStartDate(DateTimeOffset.Now);

            LandRealizations = new HashSet<LandRealization>();
        }

        internal void AddPlantAction(PlantAction plantAction, LandId landId)
        {
            var landRealization = GetLandRealizationByLandId(landId);
            if (landRealization is null)
            {
                landRealization = new LandRealization(landId);
                LandRealizations.Add(landRealization);
                AddEvent(new LandRealizationAdded(this, landRealization));
            }

            landRealization.AddPlantAction(plantAction);
        }

        private LandRealization GetLandRealizationByLandId(LandId landId)
        {
            return LandRealizations.FirstOrDefault(x => x.LandId == landId);
        }
    }
}
