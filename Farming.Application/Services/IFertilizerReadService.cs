
namespace Farming.Application.Services
{
    public interface IFertilizerReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
