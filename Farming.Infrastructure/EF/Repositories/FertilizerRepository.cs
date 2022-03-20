using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public sealed class FertilizerRepository : IFertilizerRepository
    {
        private readonly DbSet<Fertilizer> _fertilizers;
        private readonly WriteDbContext _writeDbContext;

        public FertilizerRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _fertilizers = writeDbContext.Fertilizers;
        }

        public Task<Fertilizer> GetAsync(FertilizerId id)
        {
            return _fertilizers.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
