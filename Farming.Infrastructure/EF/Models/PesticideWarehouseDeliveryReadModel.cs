
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideWarehouseDeliveryReadModel
    {
        public Guid Id { get; set; }
        public Guid PesticideId { get; set; }
        public Guid PesticideWarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset RealizationDate { get; set; }

        public PesticideReadModel Pesticide { get; set; }
        public PesticideWarehouseReadModel PesticideWarehouse { get; set; }
    }
}
