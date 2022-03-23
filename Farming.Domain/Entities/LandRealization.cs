using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.Season;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class LandRealization : AggregateRoot<LandRealizationId>
    {
        public LandRealizationId Id { get; }
        public LandId LandId { get; }
        public SeasonId SeasonId { get; }
        public PlantActionId PlantActionId { get; }

        public Land Land { get; }
        public Season Season { get; }
        public ICollection<PlantAction> PlantActions { get; }
        public ICollection<FertilizerAction> FertilizerActions { get; }
        public ICollection<PesticideAction> PesticideActions { get; }
    }
}
