using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;

namespace Farming.Domain.Repositories
{
    public interface IPlantRepository
    {
        Task<Plant> GetAsync(PlantId id);
    }
}
