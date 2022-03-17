using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly DbSet<Season> _seasons;
        private readonly WriteDbContext _writeDbContext;

        public SeasonRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _seasons = writeDbContext.Seasons;
        }

        public async Task AddAsync(Season season)
        {
            await _seasons.AddAsync(season);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
