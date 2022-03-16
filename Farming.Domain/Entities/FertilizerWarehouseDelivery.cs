﻿using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerWarehouseDelivery : AggregateRoot<FertilizerWarehouseDeliveryId>
    {
        public FertilizerWarehouseDeliveryId Id { get; }
        public FertilizerId FertilizerId { get; }
        public FertilizerWarehouseStateId FertilizerWarehouseStateId { get; private set; }
        public UserId UserId { get; }
        public FertilizerWarehouseDeliveryQuantity Quantity { get; }
        public FertilizerWarehouseDeliveryPrice Price { get; }
        public FertilizerWarehouseDeliveryRealizationDate RealizationDate { get; }

        public Fertilizer Fertilizer { get; }
        public FertilizerWarehouseState FertilizerWarehouseState { get; }
        public User User { get; }

        public FertilizerWarehouseDelivery(FertilizerWarehouseDeliveryId id, FertilizerId fertilizerId, UserId userId,
            FertilizerWarehouseDeliveryQuantity quantity, FertilizerWarehouseDeliveryPrice price, FertilizerWarehouseDeliveryRealizationDate realizationDate)
        {
            Id = id;
            FertilizerId = fertilizerId;
            UserId = userId;
            Quantity = quantity;
            Price = price;
            RealizationDate = realizationDate;
        }

        public void SetWarehouseStateId(FertilizerWarehouseStateId stateId)
        {
            FertilizerWarehouseStateId = stateId;
        }
    }
}
