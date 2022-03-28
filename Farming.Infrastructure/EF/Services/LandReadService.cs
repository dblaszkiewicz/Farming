using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class LandReadService : ILandReadService
    {
        private readonly DbSet<LandReadModel> _dbSet;

        public LandReadService(ReadDbContext context)
        {
            _dbSet = context.Lands;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}
