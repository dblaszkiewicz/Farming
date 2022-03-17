using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouse : AggregateRoot<PesticideWarehouseId>
    {
        public PesticideWarehouseId Id { get; }

        public ICollection<PesticideWarehouseState> States { get; }

        public PesticideWarehouse()
        {
            Id = new PesticideWarehouseId(Guid.NewGuid());
            States = new HashSet<PesticideWarehouseState>();
        }
    }
}
