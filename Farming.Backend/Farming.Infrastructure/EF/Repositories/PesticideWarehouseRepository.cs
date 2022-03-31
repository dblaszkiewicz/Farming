using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class PesticideWarehouseRepository : IPesticideWarehouseRepository
    {
        private readonly DbSet<PesticideWarehouse> _dbSet;

        public PesticideWarehouseRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.PesticideWarehouses;
        }

        public async Task AddAsync(PesticideWarehouse pesticideWarehouse)
        {
            await _dbSet.AddAsync(pesticideWarehouse);
        }

        public Task<PesticideWarehouse> GetWithStatesAndDeliveriesAsync(PesticideWarehouseId id)
        {
            return _dbSet
                .Include(x => x.States)
                    .ThenInclude(x => x.PesticideWarehouseDeliveries)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<PesticideWarehouse> GetWithStatesAsync(PesticideWarehouseId id)
        {
            return _dbSet
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(PesticideWarehouse pesticideWarehouse)
        {
            _dbSet.Update(pesticideWarehouse);
        }
    }
}
