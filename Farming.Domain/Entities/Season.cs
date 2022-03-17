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
    }
}
