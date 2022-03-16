
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerWarehouseDeliveryReadModel
    {
        public Guid Id { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid FertilizerWarehouseId { get; set; }
        public Guid UserId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset RealizationDate { get; set; }

        public FertilizerReadModel Fertilizer { get; set; }
        public FertilizerWarehouseStateReadModel FertilizerWarehouseState { get; set; }
        public UserReadModel User { get; set; }
    }
}
