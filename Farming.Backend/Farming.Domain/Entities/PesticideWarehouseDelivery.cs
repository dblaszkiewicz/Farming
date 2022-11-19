using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Farming.UnitTests")]
namespace Farming.Domain.Entities
{
    public class PesticideWarehouseDelivery : Tenant
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

        internal PesticideWarehouseDelivery(PesticideId pesticideId, UserId userId,
            PesticideWarehouseDeliveryQuantity quantity, PesticideWarehouseDeliveryPrice price,
            PesticideWarehouseDeliveryRealizationDate realizationDate)
        {
            Id = new PesticideWarehouseDeliveryId(Guid.NewGuid());
            PesticideId = pesticideId;
            UserId = userId;
            Quantity = quantity;
            Price = price;
            RealizationDate = realizationDate;
        }
    }
}
