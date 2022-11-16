
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerWarehouseStateReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid FertilizerWarehouseId { get; set; }
        public decimal Quantity { get; set; }

        public FertilizerReadModel Fertilizer { get; }
        public FertilizerWarehouseReadModel FertilizerWarehouse { get; }
        public ICollection<FertilizerWarehouseDeliveryReadModel> FertilizerWarehouseDeliveries { get; }
    }
}
