using Farming.Domain.ValueObjects.Land;

namespace Farming.Domain.Entities
{
    public class Land
    {
        public LandId Id { get; }
        public LandClass Class { get; }
        public LandStatus Status { get; }
        public LandName Name { get; }
        public LandArea Area { get; }

        public ICollection<LandRealization> LandRealizations { get; }
    }
}
