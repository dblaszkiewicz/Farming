using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouse
    {
        public PesticideWarehouseId Id { get; }
        public PesticideId PesticideId { get; }
        public PesticideTypeId PesticideTypeId { get; }
        public PesticideWarehouseQuantity Quantity { get; }

        public Pesticide Pesticide { get; }
        public PesticideType PesticideType { get; }
        public ICollection<PesticideWarehouseDelivery> PesticideWarehouseDeliveries { get; }
    }
}
