using Farming.Domain.Entities;

namespace Farming.Domain.Repositories
{
    public interface IPesticideWarehouseRepository
    {
        Task AddAsync(PesticideWarehouse pesticideWarehouse);
    }
}
