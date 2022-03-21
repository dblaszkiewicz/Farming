﻿using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class Fertilizer : AggregateRoot<FertilizerId>
    {
        public FertilizerId Id { get; }
        public FertilizerTypeId FertilizerTypeId { get; }
        public FertilizerRequiredAmountPerHectare RequiredAmountPerHectare { get; }
        public FertilizerName Name { get; }
        public FertilizerDescription Description { get; }

        public FertilizerType FertilizerType { get; }
        public ICollection<Plant> SuitablePlants { get; }
        public ICollection<FertilizerWarehouseDelivery> FertilizerWarehouseDeliveries { get; }
        public ICollection<FertilizerWarehouseState> FertilizerWarehouseStates { get; }
        public ICollection<FertilizerAction> FertilizerActions { get; }

        public Fertilizer(FertilizerRequiredAmountPerHectare requiredAmountPerHectare, FertilizerName name, FertilizerDescription description)
        {
            Id = new FertilizerId(Guid.NewGuid());
            RequiredAmountPerHectare = requiredAmountPerHectare;
            Name = name;
            Description = description;

            SuitablePlants = new HashSet<Plant>();
            FertilizerWarehouseDeliveries = new HashSet<FertilizerWarehouseDelivery>();
            FertilizerWarehouseStates = new HashSet<FertilizerWarehouseState>();
            FertilizerActions = new HashSet<FertilizerAction>();
        }

        public void AddSutiablePlants(IEnumerable<Plant> plants)
        {
            foreach (var plant in plants)
            {
                SuitablePlants.Add(plant);
            }
        }
    }
}
