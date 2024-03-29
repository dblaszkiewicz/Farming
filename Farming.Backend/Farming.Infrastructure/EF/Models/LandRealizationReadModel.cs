﻿
namespace Farming.Infrastructure.EF.Models
{
    internal class LandRealizationReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public Guid LandId { get; set; }
        public Guid SeasonId { get; set; }
        public int Version { get; set; }

        public LandReadModel Land { get; set; }
        public SeasonReadModel Season { get; set; }
        public ICollection<PlantActionReadModel> PlantActions { get; set; }
        public ICollection<FertilizerActionReadModel> FertilizerActions { get; set; }
        public ICollection<PesticideActionReadModel> PesticideActions { get; set; }
    }
}
