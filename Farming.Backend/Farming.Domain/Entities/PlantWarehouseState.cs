using Farming.Domain.Events;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Farming.UnitTests")]
namespace Farming.Domain.Entities
{
    public class PlantWarehouseState : AggregateRoot<PlantWarehouseStateId>
    {
        public PlantId PlantId { get; }
        public PlantWarehouseId PlantWarehouseId { get; }
        public PlantWarehouseQuantity Quantity { get; private set; }

        public Plant Plant { get; }
        public PlantWarehouse PlantWarehouse { get; }
        public ICollection<PlantWarehouseDelivery> PlantWarehouseDeliveries { get; }

        internal PlantWarehouseState(PlantId plantId)
        {
            Id = new PlantWarehouseStateId(Guid.NewGuid());
            Quantity = new PlantWarehouseQuantity(0);
            PlantId = plantId;

            PlantWarehouseDeliveries = new HashSet<PlantWarehouseDelivery>();
        }

        internal void AddDelivery(PlantWarehouseDelivery delivery)
        {
            var newQuantity = Quantity + delivery.Quantity;

            Quantity = new PlantWarehouseQuantity(newQuantity);

            PlantWarehouseDeliveries.Add(delivery);

            AddEvent(new PlantWarehouseStateDeliveryAdded(this, delivery));
            IncrementVersion();
        }

        internal void SpendPlants(PlantActionQuantity quantity)
        {
            var newQuantity = Quantity - quantity;

            Quantity = new PlantWarehouseQuantity(newQuantity);

            AddEvent(new PlantWarehouseStateSpendPlants(this, quantity));
            IncrementVersion();
        }
    }
}
