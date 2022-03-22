using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerWarehouseState : AggregateRoot<FertilizerWarehouseStateId>
    {
        public FertilizerWarehouseStateId Id { get; }
        public FertilizerId FertilizerId { get; private set; }
        public FertilizerWarehouseId FertilizerWarehouseId { get; private set; }
        public FertilizerWarehouseQuantity Quantity { get; private set; }
        
        public Fertilizer Fertilizer { get; }
        public FertilizerWarehouse FertilizerWarehouse { get; }
        public ICollection<FertilizerWarehouseDelivery> FertilizerWarehouseDeliveries { get; }

        public FertilizerWarehouseState()
        {
            // for EF
        }

        public FertilizerWarehouseState(FertilizerId fertilizerId)
        {
            Id = new FertilizerWarehouseStateId(Guid.NewGuid());
            Quantity = new FertilizerWarehouseQuantity(0);
            FertilizerId = fertilizerId;

            FertilizerWarehouseDeliveries = new HashSet<FertilizerWarehouseDelivery>();
        }

        public void AddDelivery(FertilizerWarehouseDelivery delivery)
        {
            FertilizerWarehouseDeliveries.Add(delivery);
            Quantity.Append(delivery.Quantity);
            AddEvent(new FertilizerWarehouseStateDeliveryAdded(this, delivery));
        }
    }
}
