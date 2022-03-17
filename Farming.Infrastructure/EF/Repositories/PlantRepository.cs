using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class PlantRepository : IPlantRepository
    {
        private readonly DbSet<Plant> _plants;
        private readonly WriteDbContext _writeDbContext;

        public PlantRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _plants = _writeDbContext.Plants;
        }

        public async Task AddAsync(Plant plant)
        {
            await _plants.AddAsync(plant);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
