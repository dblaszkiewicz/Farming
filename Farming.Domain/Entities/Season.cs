using Farming.Domain.ValueObjects.Season;

namespace Farming.Domain.Entities
{
    public class Season
    {
        public SeasonId Id { get; }
        public SeasonActive Active { get; }
        public SeasonStartDate StartDate { get; }
        public SeasonEndDate EndDate { get; } 
    }
}
