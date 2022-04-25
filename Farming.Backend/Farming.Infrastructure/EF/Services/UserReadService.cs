using Farming.Application.Services;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Services
{
    internal sealed class UserReadService : IUserReadService
    {
        private readonly DbSet<UserReadModel> _dbSet;

        public UserReadService(ReadDbContext context)
        {
            _dbSet = context.Users;
        }

        public Task<bool> ExistsByIdAsync(Guid id)
        {
            return _dbSet.AnyAsync(x => x.Id == id);
        }

        public Task<bool> IsLoginUnique(string login)
        {
            return _dbSet.AnyAsync(x => x.Login == login.ToLower());
        }
    }
}
