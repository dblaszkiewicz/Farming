
namespace Farming.Application.Services
{
    public interface IPesticideReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
