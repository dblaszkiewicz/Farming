using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class FertilizerWarehouseRepository : IFertilizerWarehouseRepository
    {
        private readonly DbSet<FertilizerWarehouse> _dbSet;

        public FertilizerWarehouseRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.FertilizerWarehouses;
        }

        public async Task AddAsync(FertilizerWarehouse fertilizerWarehouse)
        {
            await _dbSet.AddAsync(fertilizerWarehouse);
        }

        public Task<FertilizerWarehouse> GetWithStateAndDeliveriesAsync(FertilizerWarehouseId id)
        {
            return _dbSet
                .Include(x => x.States)
                    .ThenInclude(x => x.FertilizerWarehouseDeliveries)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<FertilizerWarehouse> GetWithStatesAsync(FertilizerWarehouseId id)
        {
            return _dbSet
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(FertilizerWarehouse fertilizerWarehouse)
        {
            _dbSet.Update(fertilizerWarehouse);
        }
    }
}
