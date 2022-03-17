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
    }
}
