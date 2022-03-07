using Farming.Domain.ValueObjects.Fertilizer;

namespace Farming.Domain.Entities
{
    public class FertilizerWarehouse
    {
        public FertilizerWarehouseId Id { get; }
        public FertilizerId FertilizerId { get; }
        public FertilizerTypeId FertilizerTypeId { get; } 
        public FertilizerWarehouseQuantity Quantity { get; }

        public Fertilizer Fertilizer { get; }
        public FertilizerType FertilizerType { get; }
        public ICollection<FertilizerWarehouseDelivery> FertilizerWarehouseDeliveries { get; }
    }
}
