﻿using Farming.Domain.Events;
using Farming.Domain.Exceptions;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantWarehouse : AggregateRoot<PlantWarehouseId>
    {
        public PlantWarehouseName Name { get; }

        public ICollection<PlantWarehouseState> States { get; }

        public PlantWarehouse()
        {
        }

        public PlantWarehouse(PlantWarehouseName name, List<PlantWarehouseState> states)
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

        public void ProcessPlantAction(PlantId plantId, PlantActionQuantity quantity)
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
