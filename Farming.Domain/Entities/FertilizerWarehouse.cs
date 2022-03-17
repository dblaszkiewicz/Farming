using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerWarehouse : AggregateRoot<FertilizerWarehouseId>
    {
        public FertilizerWarehouseId Id { get; }
        public ICollection<FertilizerWarehouseState> States { get; }

        public FertilizerWarehouse()
        {
            Id = new FertilizerWarehouseId(Guid.NewGuid());
            States = new HashSet<FertilizerWarehouseState>();
        }

        public void AddDelivery(FertilizerWarehouseDelivery delivery)
        {
            var state = GetStateByFertilizerId(delivery.FertilizerId);
            if (state == null)
            {
                var stateId = new FertilizerWarehouseStateId(Guid.NewGuid());
                state = new FertilizerWarehouseState(stateId, delivery.FertilizerId, Id);
                States.Add(state);
            }

            delivery.SetWarehouseStateId(state.Id);

            state.AddDelivery(delivery);
            AddEvent(new FertilizerWarehouseDeliveryAdded(this, delivery));
        }

        private FertilizerWarehouseState GetStateByFertilizerId(FertilizerId fertilizerId)
        {
            return States.FirstOrDefault(x => x.FertilizerId.Value == fertilizerId.Value);
        }
    }
}
