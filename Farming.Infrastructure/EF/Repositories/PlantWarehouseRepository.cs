using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Plant;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class PlantWarehouseRepository : IPlantWarehouseRepository
    {
        private readonly DbSet<PlantWarehouse> _plantWarehouses;
        private readonly WriteDbContext _writeDbContext;

        public PlantWarehouseRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _plantWarehouses = writeDbContext.PlantWarehouses;
        }

        public async Task AddAsync(PlantWarehouse plantWarehouse)
        {
            await _plantWarehouses.AddAsync(plantWarehouse);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<PlantWarehouse> GetAsync(PlantWarehouseId id)
        {
            return _plantWarehouses
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(PlantWarehouse plantWarehouse)
        {
            _plantWarehouses.Update(plantWarehouse);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
