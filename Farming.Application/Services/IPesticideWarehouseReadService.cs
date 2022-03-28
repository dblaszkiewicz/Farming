
namespace Farming.Application.Services
{
    public interface IPesticideWarehouseReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
