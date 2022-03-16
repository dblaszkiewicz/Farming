using Farming.Domain.ValueObjects.Season;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Season : AggregateRoot<SeasonId>
    {
        public SeasonId Id { get; }
        public SeasonActive Active { get; }
        public SeasonStartDate StartDate { get; }
        public SeasonEndDate EndDate { get; } 

        public ICollection<LandRealization> LandRealizations { get; }
    }
}
