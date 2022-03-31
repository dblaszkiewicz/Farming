using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface IPesticideTypeRepository
    {
        Task AddAsync(PesticideType pesticideType);
    }
}
