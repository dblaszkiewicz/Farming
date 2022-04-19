using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface ISeasonRepository
    {
        Task AddAsync(Season season);
        Task<Season> GetCurrentSeasonAsync();
        Task<Season> GetCurrentSeasonWithPlantActionsAsync();
        Task<Season> GetCurrentSeasonWithPesticideActionsAsync();
        Task<Season> GetCurrentSeasonWithFertilzierActionsAsync();
        Task UpdateAsync(Season season);
    }
}
