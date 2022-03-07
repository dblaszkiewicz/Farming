using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouseDelivery
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
