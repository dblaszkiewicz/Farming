using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class FertilizerWarehouseReadService : IFertilizerWarehouseReadService
    {
        private readonly DbSet<FertilizerWarehouseReadModel> _dbSet;

        public FertilizerWarehouseReadService(ReadDbContext context)
        {
            _dbSet = context.FertilizerWarehouses;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}
