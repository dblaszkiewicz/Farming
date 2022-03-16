using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouse : AggregateRoot<PesticideWarehouseId>
    {
        public PesticideWarehouseId Id { get; }

        public ICollection<FertilizerWarehouseState> States { get; }
    }
}
