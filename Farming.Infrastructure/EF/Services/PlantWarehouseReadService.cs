using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class PlantWarehouseReadService : IPlantWarehouseReadService
    {
        private readonly DbSet<PlantWarehouseReadModel> _dbSet;

        public PlantWarehouseReadService(ReadDbContext context)
        {
            _dbSet = context.PlantWarehouses;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}
