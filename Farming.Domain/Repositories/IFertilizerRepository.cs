using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;

namespace Farming.Domain.Repositories
{
    public interface IFertilizerRepository
    {
        Task<Fertilizer> GetAsync(FertilizerId id);
    }
}
