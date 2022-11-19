

namespace Farming.Infrastructure.EF.Models
{
    internal class LandReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string LandClass { get; set; }
        public string Name { get; set; }
        public decimal Area { get; set; }
        public int Version { get; set; }

        public ICollection<LandRealizationReadModel> LandRealizations { get; set; }

        internal LandReadModel(string landClass, string name, decimal area)
        {
            Id = Guid.NewGuid();
            Status = 2;
            LandClass = landClass;
            Name = name;
            Area = area;

            LandRealizations = new HashSet<LandRealizationReadModel>();
        }
    }
}
