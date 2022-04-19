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

        public Task<Season> GetCurrentSeasonWithFertilzierActionsAsync()
        {
            return _dbSet
                .Include(x => x.LandRealizations)
                    .ThenInclude(x => x.FertilizerActions)
                .FirstOrDefaultAsync(x => x.Active);
        }

        public Task<Season> GetCurrentSeasonWithPesticideActionsAsync()
        {
            return _dbSet
                .Include(x => x.LandRealizations)
                    .ThenInclude(x => x.PesticideActions)
                .FirstOrDefaultAsync(x => x.Active);
        }

        public Task<Season> GetCurrentSeasonWithPlantActionsAsync()
        {
            return _dbSet
                .Include(x => x.LandRealizations)
                    .ThenInclude(x => x.PlantActions)
                .FirstOrDefaultAsync(x => x.Active);
        }

        public async Task UpdateAsync(Season season)
        {
            _dbSet.Update(season);
        }
    }
}
