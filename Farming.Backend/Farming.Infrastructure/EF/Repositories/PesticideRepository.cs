using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class PesticideRepository : IPesticideRepository
    {
        private readonly DbSet<Pesticide> _dbSet;

        public PesticideRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.Pesticides;
        }

        public Task<Pesticide> GetAsync(PesticideId id)
        {
            return _dbSet.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
