
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideWarehouseReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }

        public ICollection<PesticideWarehouseStateReadModel> States { get; }

        internal PesticideWarehouseReadModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            States = new HashSet<PesticideWarehouseStateReadModel>();
        }
    }
}
