
namespace Farming.Application.Services
{
    public interface IUserReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
        Task<bool> IsLoginUnique(string login);
        Task<bool> IsAdmin(Guid id);
        Task<bool> AreMoreActiveAdministrators(Guid id);
    }
}
