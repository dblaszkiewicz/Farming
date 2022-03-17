using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class PesticideTypeRepository : IPesticideTypeRepository
    {
        private readonly DbSet<PesticideType> _pesticideTypes;
        private readonly WriteDbContext _writeDbContext;

        public PesticideTypeRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _pesticideTypes = writeDbContext.PesticideTypes;
        }

        public async Task AddAsync(PesticideType pesticide)
        {
            await _pesticideTypes.AddAsync(pesticide);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
