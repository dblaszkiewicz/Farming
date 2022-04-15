
namespace Farming.Infrastructure.EF.Models
{
    internal class SeasonReadModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTimeOffset StartDate { get; set; }

        public ICollection<LandRealizationReadModel> LandRealizations { get; set; }
    }
}
