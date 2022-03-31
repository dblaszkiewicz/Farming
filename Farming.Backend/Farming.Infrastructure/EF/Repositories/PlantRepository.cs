using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Plant;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class PlantRepository : IPlantRepository
    {
        private readonly DbSet<Plant> _dbSet;

        public PlantRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.Plants;
        }

        public Task<Plant> GetAsync(PlantId id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
