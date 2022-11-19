
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideWarehouseStateReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public Guid PesticideId { get; set; }
        public Guid PesticideWarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public int Version { get; set; }

        public PesticideReadModel Pesticide { get; set; }
        public PesticideWarehouseReadModel PesticideWarehouse { get; }

        public ICollection<PesticideWarehouseDeliveryReadModel> PesticideWarehouseDeliveries { get; }
    }
}
