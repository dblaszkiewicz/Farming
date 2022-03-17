using Farming.Domain.ValueObjects.Land;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Land : AggregateRoot<LandId>
    {
        public LandId Id { get; }
        public LandClass LandCLass { get; }
        public LandStatus Status { get; }
        public LandName Name { get; }
        public LandArea Area { get; }

        public ICollection<LandRealization> LandRealizations { get; }

        // for EF
        public Land()
        {

        }

        public Land(LandClass landClass, LandStatus status, LandName name, LandArea area)
        {
            Id = new LandId(Guid.NewGuid());
            LandCLass = landClass;
            Status = status;
            Name = name;
            Area = area;

            LandRealizations = new HashSet<LandRealization>();
        }
    }
}
