using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Plant;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class PlantWarehouseRepository : IPlantWarehouseRepository
    {
        private readonly DbSet<PlantWarehouse> _dbSet;

        public PlantWarehouseRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.PlantWarehouses;
        }

        public async Task AddAsync(PlantWarehouse plantWarehouse)
        {
            await _dbSet.AddAsync(plantWarehouse);
        }

        public Task<PlantWarehouse> GetWithStatesAsync(PlantWarehouseId id)
        {
            return _dbSet
                .Include(x => x.States)
                .FirstAsync(x => x.Id == id);
        }

        public Task<PlantWarehouse> GetWithStatesAndDeliveriesAsync(PlantWarehouseId id)
        {
            return _dbSet
                .Include(x => x.States)
                    .ThenInclude(x => x.PlantWarehouseDeliveries)
                .FirstAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(PlantWarehouse plantWarehouse)
        {
            _dbSet.Update(plantWarehouse);
        }
    }
}
