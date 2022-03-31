using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PesticideWarehouseStateSpendPesticide(PesticideWarehouseState PesticideWarehouseState,
        PesticideActionQuantity PesticideActionQuantity) : IDomainEvent;
}
