using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Land;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal class LandRepository : ILandRepository
    {
        private readonly DbSet<Land> _dbSet;

        public LandRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.Lands;

        }
        public async Task AddAsync(Land land)
        {
            await _dbSet.AddAsync(land);
        }

        public Task<Land> GetAsync(LandId id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Land land)
        {
            _dbSet.Update(land);
        }
    }
}
