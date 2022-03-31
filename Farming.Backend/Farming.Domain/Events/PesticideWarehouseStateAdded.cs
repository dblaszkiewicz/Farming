using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PesticideWarehouseStateAdded(PesticideWarehouse PesticideWarehouse,
        PesticideWarehouseState PesticideWarehouseState) : IDomainEvent;
}
