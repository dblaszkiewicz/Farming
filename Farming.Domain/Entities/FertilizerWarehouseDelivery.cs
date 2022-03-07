using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Entities
{
    public class FertilizerWarehouseDelivery
    {
        public FertilizerWarehouseDeliveryId Id { get; }
        public FertilizerId FertilizerId { get; }
        public FertilizerWarehouseId FertilizerWarehouseId { get; }
        public UserId UserId { get; }
        public FertilizerWarehouseDeliveryQuantity Quantity { get; }
        public FertilizerWarehouseDeliveryPrice Price { get; }
        public FertilizerWarehouseDeliveryRealizationDate RealizationDate { get; }

        public Fertilizer Fertilizer { get; }
        public FertilizerWarehouse FertilizerWarehouse { get; }
        public User User { get; }
    }
}
