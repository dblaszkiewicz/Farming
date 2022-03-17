using Farming.Domain.Entities;
using Farming.Domain.Repositories;
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
    }
}
