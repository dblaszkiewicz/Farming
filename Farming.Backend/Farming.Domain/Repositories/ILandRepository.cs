using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;

namespace Farming.Domain.Repositories
{
    public interface ILandRepository
    {
        Task AddAsync(Land land);
        Task<Land> GetAsync(LandId id);
        Task UpdateAsync(Land land);
    }
}
