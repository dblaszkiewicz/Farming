using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;

namespace Farming.Domain.Repositories
{
    public interface IPesticideWarehouseRepository
    {
        Task AddAsync(PesticideWarehouse pesticideWarehouse);
        Task<PesticideWarehouse> GetWithStatesAndDeliveriesAsync(PesticideWarehouseId id);
        Task<PesticideWarehouse> GetWithStatesAsync(PesticideWarehouseId id);
        Task UpdateAsync(PesticideWarehouse pesticideWarehouse);
    }
}
