﻿using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Identity;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class LandRealization : AggregateRoot<LandRealizationId>
    {
        public LandId LandId { get; }
        public SeasonId SeasonId { get; }

        public Land Land { get; }
        public Season Season { get; }
        public ICollection<PlantAction> PlantActions { get; }
        public ICollection<FertilizerAction> FertilizerActions { get; }
        public ICollection<PesticideAction> PesticideActions { get; }

        internal LandRealization(LandId landId)
        {
            Id = new LandRealizationId(Guid.NewGuid());
            LandId = landId;

            PlantActions = new HashSet<PlantAction>();
            FertilizerActions = new HashSet<FertilizerAction>();
            PesticideActions = new HashSet<PesticideAction>();
        }

        internal void AddPlantAction(PlantAction plantAction)
        {
            PlantActions.Add(plantAction);
            AddEvent(new PlantActionAdded(this, plantAction));
            IncrementVersion();
        }

        internal void AddFertilizerAction(FertilizerAction fertilizerAction)
        {
            FertilizerActions.Add(fertilizerAction);
            AddEvent(new FertilizerActionAdded(this, fertilizerAction));
            IncrementVersion();
        }

        internal void AddPesticideAction(PesticideAction pesticideAction)
        {
            PesticideActions.Add(pesticideAction);
            AddEvent(new PesticideActionAdded(this, pesticideAction));
            IncrementVersion();
        }
    }
}
