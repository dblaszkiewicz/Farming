using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;

namespace Farming.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(UserId id);
    }
}
