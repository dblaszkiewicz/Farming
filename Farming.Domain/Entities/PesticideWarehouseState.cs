using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouseState : AggregateRoot<PesticideWarehouseStateId>
    {
        public PesticideWarehouseStateId Id { get; }
        public PesticideId PesticideId { get; }
        public PesticideWarehouseId PesticideWarehouseId { get; }
        public PesticideWarehouseQuantity Quantity { get; private set; }

        public Pesticide Pesticide { get; }
        public PesticideWarehouse PesticideWarehouse { get; }
        public ICollection<PesticideWarehouseDelivery> PesticideWarehouseDeliveries { get; }
    }
}
