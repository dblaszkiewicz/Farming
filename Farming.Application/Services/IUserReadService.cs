
namespace Farming.Application.Services
{
    public interface IUserReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
