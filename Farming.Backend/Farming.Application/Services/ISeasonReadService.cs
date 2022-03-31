
namespace Farming.Application.Services
{
    public interface ISeasonReadService
    {
        Task<bool> ActiveSeasonExistsAsync();
    }
}
