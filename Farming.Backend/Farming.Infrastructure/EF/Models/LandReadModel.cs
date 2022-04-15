
namespace Farming.Infrastructure.EF.Models
{
    internal class LandReadModel
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string LandClass { get; set; }
        public string Name { get; set; }
        public decimal Area { get; set; }

        public ICollection<LandRealizationReadModel> LandRealizations { get; set; }
    }
}
