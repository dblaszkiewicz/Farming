using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
