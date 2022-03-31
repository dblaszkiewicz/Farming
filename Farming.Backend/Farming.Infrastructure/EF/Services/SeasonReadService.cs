using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class SeasonReadService : ISeasonReadService
    {
        private readonly DbSet<SeasonReadModel> _dbSet;

        public SeasonReadService(ReadDbContext context)
        {
            _dbSet = context.Seasons;
        }

        public Task<bool> ActiveSeasonExistsAsync()
        {
            return _dbSet.AnyAsync(x => x.Active);
        }
    }
}
