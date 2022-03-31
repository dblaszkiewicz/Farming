using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface IFertilizerTypeRepository
    {
        Task AddAsync(FertilizerType fertilizerType);
    }
}
