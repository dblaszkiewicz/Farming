using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideWarehouseDelivery : AggregateRoot<PesticideWarehouseDeliveryId>
    {
        public PesticideWarehouseDeliveryId Id { get; }
        public PesticideId PesticideId { get; }
        public PesticideWarehouseStateId PesticideWarehouseStateId { get; }
        public UserId UserId { get; }
        public PesticideWarehouseDeliveryQuantity Quantity { get; }
        public PesticideWarehouseDeliveryPrice Price { get; }
        public PesticideWarehouseDeliveryRealizationDate RealizationDate { get; }

        public Pesticide Pesticide { get; }
        public User User { get; }
        public PesticideWarehouseState PesticideWarehouseState { get; }
    }
}
