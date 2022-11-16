using Farming.Domain.Events;
using Farming.Domain.Exceptions;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerWarehouse : AggregateRoot<FertilizerWarehouseId>
    {
        public FertilizerWarehouseName Name { get; }

        public ICollection<FertilizerWarehouseState> States { get; }

        public FertilizerWarehouse()
        {
        }

        public FertilizerWarehouse(FertilizerWarehouseName name, List<FertilizerWarehouseState> states)
        {
            Id = new FertilizerWarehouseId(Guid.NewGuid());

            Name = name;
            States = states;
        }

        public void AddDelivery(FertilizerWarehouseDelivery delivery)
        {
            var state = GetStateByFertilizerId(delivery.FertilizerId);
            if (state is null)
            {
                state = new FertilizerWarehouseState(delivery.FertilizerId);
                States.Add(state);
                AddEvent(new FertilizerWarehouseStateAdded(this, state));
                IncrementVersion();
            }

            state.AddDelivery(delivery);
        }

        public void ProcessFertilizerAction(FertilizerId fertilizerId, FertilizerActionQuantity quantity)
        {
            var state = GetStateByFertilizerId(fertilizerId);
            if (state is null)
            {
                throw new FertilizerWarehouseStateNotFoundException(fertilizerId, Id);
            }

            if (!state.IsEnoughFertilizer(new FertilizerWarehouseQuantity(quantity)))
            {
                throw new FertilizerActionNotEnoughQuantityException(quantity);
            }

            state.SpendFertilizer(quantity);
        }

        private FertilizerWarehouseState GetStateByFertilizerId(FertilizerId fertilizerId)
        {
            return States.FirstOrDefault(x => x.FertilizerId == fertilizerId);
        }
    }
}
