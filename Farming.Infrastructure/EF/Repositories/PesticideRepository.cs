using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class PesticideRepository : IPesticideRepository
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly DbSet<Pesticide> _pesticides;

        public PesticideRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _pesticides = writeDbContext.Pesticides;
        }

        public Task<Pesticide> GetAsync(PesticideId id)
        {
            return _pesticides.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
