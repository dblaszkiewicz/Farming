﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Factories
{
    public class PlantActionFactory : IPlantActionFactory
    {
        public PlantAction Create(PlantId plantId, UserId userId, PlantActionQuantity quantity)
        {
            var realizationDate = new PlantActionRealizationDate(DateTimeOffset.UtcNow);

            return new PlantAction(plantId, userId, quantity, realizationDate);
        }
    }
}
