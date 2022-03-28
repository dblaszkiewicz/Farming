
namespace Farming.Application.Services
{
    public interface ILandReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
