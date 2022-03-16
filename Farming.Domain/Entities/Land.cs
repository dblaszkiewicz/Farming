using Farming.Domain.ValueObjects.Land;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Land : AggregateRoot<LandId>
    {
        public LandId Id { get; }
        public LandClass Class { get; }
        public LandStatus Status { get; }
        public LandName Name { get; }
        public LandArea Area { get; }

        public ICollection<LandRealization> LandRealizations { get; }
    }
}
