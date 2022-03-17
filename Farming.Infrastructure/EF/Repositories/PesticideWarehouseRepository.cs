using Farming.Domain.Entities;
using Farming.Domain.Repositories;
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
    }
}
