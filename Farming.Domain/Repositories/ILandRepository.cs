using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface ILandRepository
    {
        Task AddAsync(Land land);
    }
}
