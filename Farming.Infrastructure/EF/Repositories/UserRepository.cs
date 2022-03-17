using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;
        private readonly WriteDbContext _writeDbContext;

        public UserRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _users = writeDbContext.Users;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
