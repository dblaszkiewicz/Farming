using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class FertilizerTypeRepository : IFertilizerTypeRepository
    {
        private readonly DbSet<FertilizerType> _dbSet;

        public FertilizerTypeRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.FertilizerTypes;
        }

        public async Task AddAsync(FertilizerType fertilizerType)
        {
            await _dbSet.AddAsync(fertilizerType);
        }
    }
}
