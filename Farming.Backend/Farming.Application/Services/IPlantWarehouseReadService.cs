namespace Farming.Application.Services
{
    public interface IPlantWarehouseReadService
    {
        Task<bool> ExistsByIdAsync(Guid id);
    }
}
