using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;

namespace Farming.Domain.Repositories
{
    public interface IFertilizerWarehouseRepository
    {
        Task<FertilizerWarehouse> GetWithStateAndDeliveriesAsync(FertilizerWarehouseId id);
        Task UpdateAsync(FertilizerWarehouse fertilizerWarehouse);
        Task AddAsync(FertilizerWarehouse fertilizerWarehouse);
    }
}
