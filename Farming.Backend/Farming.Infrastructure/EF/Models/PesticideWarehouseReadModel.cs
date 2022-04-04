
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideWarehouseReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PesticideWarehouseStateReadModel> States { get; }
    }
}
