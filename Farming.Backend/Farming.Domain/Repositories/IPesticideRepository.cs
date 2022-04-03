using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;

namespace Farming.Domain.Repositories
{
    public interface IPesticideRepository
    {
        Task<Pesticide> GetAsync(PesticideId id);
    }
}
