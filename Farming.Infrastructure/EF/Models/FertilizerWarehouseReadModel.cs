
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerWarehouseReadModel
    {
        public Guid Id { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid FertilizerTypeId { get; set; }
        public decimal Quantity { get; set; }

        public FertilizerReadModel Fertilizer { get; set; }
        public FertilizerTypeReadModel FertilizerType { get; set; }
        public ICollection<FertilizerWarehouseDeliveryReadModel> FertilizerWarehouseDeliveries { get; set; }
    }
}
