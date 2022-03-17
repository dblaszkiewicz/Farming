using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface IPlantRepository
    {
        Task AddAsync(Plant plant);
    }
}
