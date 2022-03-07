﻿using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.Season;

namespace Farming.Domain.Entities
{
    public class LandRealization
    {
        public LandRealizationId Id { get; }
        public LandId LandId { get; }
        public SeasonId SeasonId { get; }
        public PlantActionId PlantActionId { get; }

        public Land Land { get; }
        public Season Season { get; }
        public PlantAction PlantAction { get; }
        public ICollection<FertilizerAction> FertilizerActions { get; }
        public ICollection<PesticideAction> PesticideActions { get; }
    }
}
