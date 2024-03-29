﻿using Farming.Domain.Consts;
using Farming.Domain.Events;
using Farming.Domain.Exceptions;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Land;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Land : AggregateRoot<LandId>
    {
        public LandClass LandClass { get; }
        public LandStatus Status { get; private set; }
        public LandName Name { get; }
        public LandArea Area { get; }

        public ICollection<LandRealization> LandRealizations { get; }

        internal void ChangeStatusAfterPlantAction()
        {
            if (!Status.IsSuitableForPlantAction())
            {
                throw new BadLandStatusForPlantActionException();
            }

            Status = new LandStatus(LandStatusEnum.Planted);
            AddEvent(new LandStatusChanged(this, Status));
            IncrementVersion();
        }

        public void ChangeStatusToDestroyed()
        {
            if (!Status.IsSuitableForDestroy())
            {
                throw new InvalidLandStatusToProcessDestroyException();
            }

            Status = new LandStatus(LandStatusEnum.Destroeyd);
            AddEvent(new LandStatusChanged(this, Status));
            IncrementVersion();
        }

        public void ChangeStatusToHarvested()
        {
            if (!Status.IsSuitableForHarvest())
            {
                throw new InvalidLandStatusToProcessHarvestException();
            }

            Status = new LandStatus(LandStatusEnum.Harvested);
            AddEvent(new LandStatusChanged(this, Status));
            IncrementVersion();
        }
    }
}
