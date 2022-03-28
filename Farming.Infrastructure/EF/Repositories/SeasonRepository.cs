using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class SeasonRepository : ISeasonRepository
    {
        private readonly DbSet<Season> _dbSet;

        public SeasonRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.Seasons;
        }

        public async Task AddAsync(Season season)
        {
            await _dbSet.AddAsync(season);
        }

        public Task<Season> GetCurrentSeasonAsync()
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Active);
        }

        public async Task UpdateAsync(Season season)
        {
            _dbSet.Update(season);
        }
    }
}
