
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideWarehouseReadModel
    {
        public Guid Id { get; set; }
        public Guid PesticideId { get; set; }
        public Guid PesticideTypeId { get; set; }
        public decimal Quantity { get; set; }

        public PesticideReadModel Pesticide { get; set; }
        public PesticideTypeReadModel PesticideType { get; set; }
        public ICollection<PesticideWarehouseDeliveryReadModel> PesticideWarehouseDeliveries { get; set; }
    }
}
