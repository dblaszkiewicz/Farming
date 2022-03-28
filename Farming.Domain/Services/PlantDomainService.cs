using Farming.Domain.Entities;
using Farming.Domain.Exceptions;

namespace Farming.Domain.Services
{
    public class PlantDomainService : IPlantDomainService
    {
        public void ProcessPlantAction(Season season, PlantWarehouse warehouse, PlantAction action, Land land, Plant plant)
        {
            if (!land.IsStatusSuitableForPlantAction())
            {
                throw new BadLandStatusForPlantActionException();
            }

            if (!plant.IsEnoughPlantForWholeArea(land.Area, action.Quantity))
            {
                throw new NotEnoughSeedsForPlantWholeLandException();
            }

            season.AddPlantAction(action, land.Id);

            warehouse.ProcessPlantAction(action.PlantId, action.Quantity);

            land.ChangeStatusAfterPlantAction();
        }
    }
}
