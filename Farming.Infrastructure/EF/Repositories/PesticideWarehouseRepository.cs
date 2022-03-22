using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class PesticideWarehouseRepository : IPesticideWarehouseRepository
    {
        private readonly DbSet<PesticideWarehouse> _pesticideWarehouses;
        private readonly WriteDbContext _writeDbContext;

        public PesticideWarehouseRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _pesticideWarehouses = writeDbContext.PesticideWarehouses;
        }

        public async Task AddAsync(PesticideWarehouse pesticideWarehouse)
        {
            await _pesticideWarehouses.AddAsync(pesticideWarehouse);
            await _writeDbContext.SaveChangesAsync();
        }

        public Task<PesticideWarehouse> GetAsync(PesticideWarehouseId id)
        {
            return _pesticideWarehouses
                .Include(x => x.States)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(PesticideWarehouse pesticideWarehouse)
        {
            _pesticideWarehouses.Update(pesticideWarehouse);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
