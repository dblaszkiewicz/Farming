using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Repositories
{
    public interface IPesticideRepository
    {
        Task<Pesticide> GetAsync(PesticideId id);
    }
}
