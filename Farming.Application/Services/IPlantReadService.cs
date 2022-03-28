
namespace Farming.Application.Services
{
    public interface IPlantReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
