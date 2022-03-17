using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface ISeasonRepository
    {
        Task AddAsync(Season season);
    }
}
