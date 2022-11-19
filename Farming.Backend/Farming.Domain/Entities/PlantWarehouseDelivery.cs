using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Farming.UnitTests")]
namespace Farming.Domain.Entities
{
    public class PlantWarehouseDelivery : Tenant
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

        internal PlantWarehouseDelivery(PlantId plantId, UserId userId,
            PlantWarehouseDeliveryQuantity quantity, PlantWarehouseDeliveryPrice price,
            PlantWarehouseDeliveryRealizationDate realizationDate)
        {
            Id = new PlantWarehouseDeliveryId(Guid.NewGuid());

            PlantId = plantId;
            UserId = userId;
            Quantity = quantity;
            Price = price;
            RealizationDate = realizationDate;
        }
    }
}
