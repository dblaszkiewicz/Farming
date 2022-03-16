using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouseDelivery : AggregateRoot<PesticideWarehouseDeliveryId>
    {
        public PesticideWarehouseDeliveryId Id { get; }
        public PesticideId PesticideId { get; }
        public PesticideWarehouseId PesticideWarehouseId { get; }
        public PesticideWarehouseDeliveryQuantity Quantity { get; }
        public PesticideWarehouseDeliveryPrice Price { get; }
        public PesticideWarehouseDeliveryRealizationDate RealizationDate { get; }

        public Pesticide Pesticide { get; }
        public PesticideWarehouse PesticideWarehouse { get; }
    }
}
