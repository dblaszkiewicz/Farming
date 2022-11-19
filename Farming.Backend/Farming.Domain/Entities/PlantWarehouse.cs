using Farming.Domain.Events;
using Farming.Domain.Exceptions;
using Farming.Domain.Policies;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Farming.UnitTests")]
namespace Farming.Domain.Entities
{
    public class PlantWarehouse : AggregateRoot<PlantWarehouseId>
    {
        public PlantWarehouseName Name { get; }

        public ICollection<PlantWarehouseState> States { get; }

        private PlantWarehouse()
        {

        }

        internal PlantWarehouse(PlantWarehouseName name, List<PlantWarehouseState> states)
        {
            Id = new PlantWarehouseId(Guid.NewGuid());

            Name = name;
            States = states;
        }

        public void AddDelivery(PlantWarehouseDelivery delivery)
        {
            var state = GetStateByPlantId(delivery.PlantId);
            if (state is null)
            {
                state = new PlantWarehouseState(delivery.PlantId);
                States.Add(state);
                AddEvent(new PlantWarehouseStateAdded(this, state));
                IncrementVersion();
            }

            state.AddDelivery(delivery);
        }

        internal void ProcessPlantAction(PlantId plantId, PlantActionQuantity quantity, 
            IPlantWarehouseStatePolicy plantWarehouseStatePolicy)
        {
            var state = GetStateByPlantId(plantId);
            if (state is null)
            {
                throw new PlantWarehouseStateNotFoundException(plantId, Id);
            }

            if (!plantWarehouseStatePolicy.IsEnoughPlants(state, new PlantWarehouseQuantity(quantity)))
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
