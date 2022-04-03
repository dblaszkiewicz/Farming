using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class FertilizerRepository : IFertilizerRepository
    {
        private readonly DbSet<Fertilizer> _dbSet;

        public FertilizerRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.Fertilizers;
        }

        public Task<Fertilizer> GetAsync(FertilizerId id)
        {
            return _dbSet.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
