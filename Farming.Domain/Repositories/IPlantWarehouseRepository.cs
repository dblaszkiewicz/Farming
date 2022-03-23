using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Repositories
{
    public interface IPlantWarehouseRepository
    {
        Task AddAsync(PlantWarehouse plantWarehouse);
        Task<PlantWarehouse> GetAsync(PlantWarehouseId id);
        Task UpdateAsync(PlantWarehouse plantWarehouse);
    }
}
