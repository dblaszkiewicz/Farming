using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class PlantReadService : IPlantReadService
    {
        private readonly DbSet<PlantReadModel> _dbSet;
        public PlantReadService(ReadDbContext context)
        {
            _dbSet = context.Plants;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}
