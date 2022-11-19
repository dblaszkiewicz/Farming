using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Farming.Domain.Policies;

namespace Farming.Domain.Services
{
    public sealed class FertilizerDomainService : IFertilizerDomainService
    {
        private readonly IFertilizerPolicy _fertilizerPolicy;
        private readonly IFertilizerWarehouseStatePolicy _warehouseStatePolicy;

        public FertilizerDomainService(IFertilizerPolicy fertilizerPolicy, 
            IFertilizerWarehouseStatePolicy warehouseStatePolicy)
        {
            _fertilizerPolicy = fertilizerPolicy;
            _warehouseStatePolicy = warehouseStatePolicy;
        }

        public void ProcessFertilizerAction(Season season, FertilizerWarehouse warehouse, 
            FertilizerAction action, Fertilizer fertilizer, Land land)
        {
            if (!_fertilizerPolicy.IsEnoughFertilizerForWholeArea(fertilizer, land.Area, action.Quantity))
            {
                throw new NotEnoughFertilizerForPlantWholeAreaException();
            }

            season.ProcessFertilizerAction(action, land.Id);

            warehouse.ProcessFertilizerAction(fertilizer.Id, action.Quantity, _warehouseStatePolicy);
        }
    }
}
