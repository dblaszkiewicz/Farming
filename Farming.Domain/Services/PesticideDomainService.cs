using Farming.Domain.Entities;
using Farming.Domain.Exceptions;

namespace Farming.Domain.Services
{
    public class PesticideDomainService : IPesticideDomainService
    {
        public void ProcessPesticideAction(Season season, PesticideWarehouse warehouse, PesticideAction action, Pesticide pesticide, Land land)
        {
            if (!pesticide.IsEnoughPesticideForWholeArea(land.Area, action.Quantity))
            {
                throw new NotEnoughPesticideForPlantWholeAreaException();
            }

            season.ProcessPesticideAction(action, land.Id);

            warehouse.ProcessPesticideAction(pesticide.Id, action.Quantity);
        }
    }
}
