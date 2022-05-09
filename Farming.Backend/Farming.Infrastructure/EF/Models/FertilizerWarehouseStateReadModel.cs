
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerWarehouseStateReadModel : BaseReadModel
    {
        public Guid Id { get; }
        public Guid FertilizerId { get; private set; }
        public Guid FertilizerWarehouseId { get; private set; }
        public decimal Quantity { get; private set; }

        public FertilizerReadModel Fertilizer { get; }
        public FertilizerWarehouseReadModel FertilizerWarehouse { get; }
        public ICollection<FertilizerWarehouseDeliveryReadModel> FertilizerWarehouseDeliveries { get; }
    }
}
