using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Farming.Domain.Policies;

namespace Farming.Domain.Services
{
    public sealed class PlantDomainService : IPlantDomainService
    {
        private readonly ILandPolicy _landPolicy;
        private readonly IPlantPolicy _plantPolicy;
        private readonly IPlantWarehouseStatePolicy _plantWarehouseStatePolicy;

        public PlantDomainService(ILandPolicy landPolicy, IPlantPolicy plantPolicy, 
            IPlantWarehouseStatePolicy plantWarehouseStatePolicy)
        {
            _landPolicy = landPolicy;
            _plantPolicy = plantPolicy;
            _plantWarehouseStatePolicy = plantWarehouseStatePolicy;
        }

        public void ProcessPlantAction(Season season, PlantWarehouse warehouse, PlantAction action, Land land, Plant plant)
        {
            if (!_landPolicy.IsStatusSuitableForPlantAction(land))
            {
                throw new BadLandStatusForPlantActionException();
            }

            if (!_plantPolicy.IsEnoughPlantForWholeArea(plant, land.Area, action.Quantity))
            {
                throw new NotEnoughSeedsForPlantWholeAreaException();
            }

            season.ProcessPlantAction(action, land.Id);

            warehouse.ProcessPlantAction(action.PlantId, action.Quantity, _plantWarehouseStatePolicy);

            land.ChangeStatusAfterPlantAction();
        }
    }
}
