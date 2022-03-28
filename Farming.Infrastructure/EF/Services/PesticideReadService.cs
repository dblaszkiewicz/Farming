using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class PesticideReadService : IPesticideReadService
    {
        private readonly DbSet<PesticideReadModel> _dbSet;

        public PesticideReadService(ReadDbContext context)
        {
            _dbSet = context.Pesticides;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }
    }
}
