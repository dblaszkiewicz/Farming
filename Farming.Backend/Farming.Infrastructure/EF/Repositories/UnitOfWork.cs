using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _writeDbContext;

        public UnitOfWork(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
        }

        public async Task CommitAsync()
        {
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
