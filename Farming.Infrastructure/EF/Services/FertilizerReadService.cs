using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class FertilizerReadService : IFertilizerReadService
    {
        private readonly DbSet<FertilizerReadModel> _dbSet;
        public FertilizerReadService(ReadDbContext context)
        {
            _dbSet = context.Fertilizers;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}
