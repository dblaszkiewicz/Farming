using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public sealed class FertilizerWarehouseRepository : IFertilizerWarehouseRepository
    {
        private readonly DbSet<FertilizerWarehouse> _fertilizerWarehouse;
        private readonly WriteDbContext _writeDbContext;

        public FertilizerWarehouseRepository(WriteDbContext writeDbContext)
        {
            _fertilizerWarehouse = writeDbContext.FertilizerWarehouses;
            _writeDbContext = writeDbContext;
        }

        public async Task AddAsync(FertilizerWarehouse fertilizerWarehouse)
        {
            await _fertilizerWarehouse.AddAsync(fertilizerWarehouse);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<FertilizerWarehouse> GetAsync(FertilizerWarehouseId id)
        {
            return _fertilizerWarehouse
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(FertilizerWarehouse fertilizerWarehouse)
        {
            _fertilizerWarehouse.Update(fertilizerWarehouse);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
