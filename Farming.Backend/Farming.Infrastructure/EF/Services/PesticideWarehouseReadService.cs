using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class PesticideWarehouseReadService : IPesticideWarehouseReadService
    {
        private readonly DbSet<PesticideWarehouseReadModel> _dbSet;

        public PesticideWarehouseReadService(ReadDbContext context)
        {
            _dbSet = context.PesticideWarehouses;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}
