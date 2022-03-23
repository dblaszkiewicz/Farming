using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantWarehouseDelivery : AggregateRoot<PlantWarehouseDeliveryId>
    {
        public PlantWarehouseDeliveryId Id { get; }
        public PlantId PlantId { get; }
        public PlantWarehouseStateId PlantWarehouseStateId { get; }
        public UserId UserId { get; }
        public PlantWarehouseDeliveryQuantity Quantity { get; }
        public PlantWarehouseDeliveryPrice Price { get; }
        public PlantWarehouseDeliveryRealizationDate RealizationDate { get; }

        public Plant Plant { get; }
        public User User { get; }
        public PlantWarehouseState PlantWarehouseState { get; }

        public PlantWarehouseDelivery()
        {
            // for EF
        }

        public PlantWarehouseDelivery(PlantWarehouseDeliveryId id, PlantId plantId, UserId userId,
            PlantWarehouseDeliveryQuantity quantity, PlantWarehouseDeliveryPrice price,
            PlantWarehouseDeliveryRealizationDate realizationDate)
        {
            Id = id;
            PlantId = plantId;
            UserId = userId;
            Quantity = quantity;
            Price = price;
            RealizationDate = realizationDate;
        }
    }
}
