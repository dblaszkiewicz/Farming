using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class LandRepository : ILandRepository
    {
        private readonly DbSet<Land> _lands;
        private readonly WriteDbContext _writeDbContext;

        public LandRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _lands = writeDbContext.Lands;

        }
        public async Task AddAsync(Land land)
        {
            await _lands.AddAsync(land);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
