using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.User;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(WriteDbContext writeDbContext)
        {
            _dbSet = writeDbContext.Users;
        }

        public async Task AddAsync(User user)
        {
            await _dbSet.AddAsync(user);
        }

        public Task<User> GetAsync(UserId id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
