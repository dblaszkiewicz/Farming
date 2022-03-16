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

        // for EF
        public FertilizerWarehouseState()
        {

        }

        public FertilizerWarehouseState(FertilizerWarehouseStateId id, FertilizerId fertilizerId, FertilizerWarehouseId fertilizerWarehouseId)
        {
            Id = id;
            FertilizerId = fertilizerId;
            FertilizerWarehouseId = fertilizerWarehouseId;
            Quantity = new FertilizerWarehouseQuantity(0);

            FertilizerWarehouseDeliveries = new HashSet<FertilizerWarehouseDelivery>();
        }

        public void AddDelivery(FertilizerWarehouseDelivery fertilizerWarehouseDelivery)
        {
            FertilizerWarehouseDeliveries.Add(fertilizerWarehouseDelivery);
            Quantity.Append(fertilizerWarehouseDelivery.Quantity.Value);
        }
    }
}
