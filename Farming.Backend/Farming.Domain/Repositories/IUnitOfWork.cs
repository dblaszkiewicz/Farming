
namespace Farming.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
