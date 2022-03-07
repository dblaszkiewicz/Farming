
namespace Farming.Infrastructure.EF.Models
{
    internal class LandRealizationReadModel
    {
        public Guid Id { get; set; }
        public Guid LandId { get; set; }
        public Guid SeasonId { get; set; }
        public Guid PlantActionId { get; set; }

        public LandReadModel Land { get; set; }
        public SeasonReadModel Season { get; set; }
        public PlantActionReadModel PlantAction { get; set; }
        public ICollection<FertilizerActionReadModel> FertilizerActions { get; set; }
        public ICollection<PesticideActionReadModel> PesticideActions { get; set; }
    }
}
