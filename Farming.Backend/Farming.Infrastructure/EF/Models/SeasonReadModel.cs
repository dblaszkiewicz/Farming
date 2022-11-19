
namespace Farming.Infrastructure.EF.Models
{
    internal class SeasonReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public int Version { get; set; }

        public ICollection<LandRealizationReadModel> LandRealizations { get; set; }
    }
}
