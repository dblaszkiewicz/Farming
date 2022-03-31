
namespace Farming.Application.Services
{
    public interface IFertilizerWarehouseReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
