using Farming.Domain.Entities;
using Farming.Domain.Exceptions;

namespace Farming.Domain.Services
{
    public class FertilizerDomainService : IFertilizerDomainService
    {
        public void ProcessFertilizerAction(Season season, FertilizerWarehouse warehouse, FertilizerAction action, Fertilizer fertilizer, Land land)
        {
            if (!fertilizer.IsEnoughFertilizerForWholeArea(land.Area, action.Quantity))
            {
                throw new NotEnoughFertilizerForPlantWholeAreaException();
            }

            season.ProcessFertilizerAction(action, land.Id);

            warehouse.ProcessFertilizerAction(fertilizer.Id, action.Quantity);
        }
    }
}
