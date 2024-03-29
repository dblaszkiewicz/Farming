﻿using Farming.Domain.Events;
using Farming.Domain.Exceptions;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Season;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Season : AggregateRoot<SeasonId>
    {
        public SeasonActive Active { get; private set; }
        public SeasonStartDate StartDate { get; }

        public ICollection<LandRealization> LandRealizations { get; }

        public Season()
        {
            Id = Guid.NewGuid();
            Active = new SeasonActive(true);
            StartDate = new SeasonStartDate(DateTimeOffset.UtcNow);

            LandRealizations = new HashSet<LandRealization>();
        }

        public void EndSeason()
        {
            if (!Active.IsActive())
            {
                throw new EndSeasonNotActiveException();
            }

            Active = new SeasonActive(false);
            AddEvent(new SeasonChangeActive(this, Active));
            IncrementVersion();
        }

        internal void ProcessPlantAction(PlantAction plantAction, LandId landId)
        {
            var landRealization = GetLandRealizationByLandId(landId);
            if (landRealization is null)
            {
                landRealization = new LandRealization(landId);
                LandRealizations.Add(landRealization);
                AddEvent(new LandRealizationAdded(this, landRealization));
                IncrementVersion();
            }

            landRealization.AddPlantAction(plantAction);
        }

        internal void ProcessFertilizerAction(FertilizerAction fertilzierAction, LandId landId)
        {
            var landRealization = GetLandRealizationByLandId(landId);
            if (landRealization is null)
            {
                landRealization = new LandRealization(landId);
                LandRealizations.Add(landRealization);
                AddEvent(new LandRealizationAdded(this, landRealization));
                IncrementVersion();
            }

            landRealization.AddFertilizerAction(fertilzierAction);
        }

        internal void ProcessPesticideAction(PesticideAction pesticideAction, LandId landId)
        {
            var landRealization = GetLandRealizationByLandId(landId);
            if (landRealization is null)
            {
                landRealization = new LandRealization(landId);
                LandRealizations.Add(landRealization);
                AddEvent(new LandRealizationAdded(this, landRealization));
                IncrementVersion();
            }

            landRealization.AddPesticideAction(pesticideAction);
        }

        private LandRealization GetLandRealizationByLandId(LandId landId)
        {
            return LandRealizations.FirstOrDefault(x => x.LandId == landId);
        }
    }
}
