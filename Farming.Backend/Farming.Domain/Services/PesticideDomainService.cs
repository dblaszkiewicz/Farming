using Farming.Domain.Entities;
using Farming.Domain.Exceptions;
using Farming.Domain.Policies;

namespace Farming.Domain.Services
{
    public sealed class PesticideDomainService : IPesticideDomainService
    {
        private readonly IPesticidePolicy _pesticidePolicy;
        private readonly IPesticideWarehouseStatePolicy _pesticideWarehouseStatePolicy;

        public PesticideDomainService(IPesticidePolicy pesticidePolicy, 
            IPesticideWarehouseStatePolicy pesticideWarehouseStatePolicy)
        {
            _pesticidePolicy = pesticidePolicy;
            _pesticideWarehouseStatePolicy = pesticideWarehouseStatePolicy;
        }

        public void ProcessPesticideAction(Season season, PesticideWarehouse warehouse, PesticideAction action, Pesticide pesticide, Land land)
        {
            if (!_pesticidePolicy.IsEnoughPesticideForWholeArea(pesticide, land.Area, action.Quantity))
            {
                throw new NotEnoughPesticideForPlantWholeAreaException();
            }

            season.ProcessPesticideAction(action, land.Id);

            warehouse.ProcessPesticideAction(pesticide.Id, action.Quantity, _pesticideWarehouseStatePolicy);
        }
    }
}
