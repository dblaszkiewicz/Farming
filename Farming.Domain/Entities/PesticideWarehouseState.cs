using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouseState : AggregateRoot<PesticideWarehouseStateId>
    {
        public PesticideWarehouseStateId Id { get; }
        public PesticideId PesticideId { get; private set; }
        public PesticideWarehouseQuantity Quantity { get; private set; }

        public Pesticide Pesticide { get; }
        public ICollection<PesticideWarehouseDelivery> PesticideWarehouseDeliveries { get; }
    }
}
