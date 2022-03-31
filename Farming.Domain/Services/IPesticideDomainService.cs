using Farming.Domain.Entities;

namespace Farming.Domain.Services
{
    public interface IPesticideDomainService
    {
        void ProcessPesticideAction(Season season, PesticideWarehouse warehouse, PesticideAction action, Pesticide pesticide, Land land);
    }
}
