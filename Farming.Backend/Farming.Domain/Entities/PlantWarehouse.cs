using Farming.Domain.Events;
using Farming.Domain.Exceptions;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantWarehouse : AggregateRoot<PlantWarehouseId>
    {
        public PlantWarehouseId Id { get; }

        public ICollection<PlantWarehouseState> States { get; }

        public PlantWarehouse()
        {
            Id = new PlantWarehouseId(Guid.NewGuid());

            States = new HashSet<PlantWarehouseState>();
        }

        public void AddDelivery(PlantWarehouseDelivery delivery)
        {
            var state = GetStateByPlantId(delivery.PlantId);
            if (state is null)
            {
                state = new PlantWarehouseState(delivery.PlantId);
                States.Add(state);
                AddEvent(new PlantWarehouseStateAdded(this, state));
            }

            state.AddDelivery(delivery);
        }

        internal void ProcessPlantAction(PlantId plantId, PlantActionQuantity quantity)
        {
            var state = GetStateByPlantId(plantId);
            if (state is null)
            {
                throw new PlantWarehouseStateNotFoundException(plantId, Id);
            }

            if (!state.IsEnoughPlants(new PlantWarehouseQuantity(quantity)))
            {
                throw new PlantActionNotEnoughQuantityException(quantity);
            }

            state.SpendPlants(quantity);
        }

        private PlantWarehouseState GetStateByPlantId(PlantId plantId)
        {
            return States.FirstOrDefault(s => s.PlantId == plantId); 
        }
    }
}
