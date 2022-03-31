using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface ISeasonRepository
    {
        Task AddAsync(Season season);
        Task<Season> GetCurrentSeasonAsync();
        Task UpdateAsync(Season season);
    }
}
