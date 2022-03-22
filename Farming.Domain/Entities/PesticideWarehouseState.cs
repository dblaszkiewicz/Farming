using Farming.Domain.Events;
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

        public PesticideWarehouseState(PesticideId pesticideId)
        {
            Id = new PesticideWarehouseStateId(Guid.NewGuid());
            Quantity = new PesticideWarehouseQuantity(0);
            PesticideId = pesticideId;

            PesticideWarehouseDeliveries = new HashSet<PesticideWarehouseDelivery>();
        }

        public void AddDelivery(PesticideWarehouseDelivery delivery)
        {
            PesticideWarehouseDeliveries.Add(delivery);
            Quantity.Append(delivery.Quantity);
            AddEvent(new PesticideWarehouseStateDeliveryAdded(this, delivery));
        }
    }
}
