using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface IPlantWarehouseRepository
    {
        Task AddAsync(PlantWarehouse plantWarehouse);
    }
}
