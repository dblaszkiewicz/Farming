using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerWarehouseState : AggregateRoot<FertilizerWarehouseStateId>
    {
        public FertilizerWarehouseStateId Id { get; }
        public FertilizerId FertilizerId { get; }
        public FertilizerWarehouseId FertilizerWarehouseId { get; }
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
            var newQuantity = Quantity + delivery.Quantity;

            Quantity = new FertilizerWarehouseQuantity(newQuantity);

            FertilizerWarehouseDeliveries.Add(delivery);

            AddEvent(new FertilizerWarehouseStateDeliveryAdded(this, delivery));
        }

        public bool IsEnoughFertilizer(FertilizerWarehouseQuantity quantity)
        {
            if (Quantity >= quantity)
            {
                return true;
            }

            return false;
        }

        internal void SpendFertilizer(FertilizerActionQuantity quantity)
        {
            var newQuantity = Quantity - quantity;

            Quantity = new FertilizerWarehouseQuantity(newQuantity);

            AddEvent(new FertilizerWarehouseStateSpendFertilizer(this, quantity));
        }
    }
}
