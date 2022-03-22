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
            if (state is null)
            {
                state = new FertilizerWarehouseState(delivery.FertilizerId);
                States.Add(state);
                AddEvent(new FertilizerWarehouseStateAdded(this, state));
            }

            state.AddDelivery(delivery);
        }

        private FertilizerWarehouseState GetStateByFertilizerId(FertilizerId fertilizerId)
        {
            return States.FirstOrDefault(x => x.FertilizerId == fertilizerId);
        }
    }
}
