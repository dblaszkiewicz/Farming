using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public sealed class FertilizerTypeRepository : IFertilizerTypeRepository
    {
        private readonly DbSet<FertilizerType> _fertilizerTypes;
        private readonly WriteDbContext _writeDbContext;

        public FertilizerTypeRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _fertilizerTypes = writeDbContext.FertilizerTypes;
        }

        public async Task AddAsync(FertilizerType fertilizerType)
        {
            await _fertilizerTypes.AddAsync(fertilizerType);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
