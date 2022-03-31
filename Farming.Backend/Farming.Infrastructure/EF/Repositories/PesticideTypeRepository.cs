using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class PesticideTypeRepository : IPesticideTypeRepository
    {
        private readonly DbSet<PesticideType> _dbSet;

        public PesticideTypeRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.PesticideTypes;
        }

        public async Task AddAsync(PesticideType pesticide)
        {
            await _dbSet.AddAsync(pesticide);
        }
    }
}
