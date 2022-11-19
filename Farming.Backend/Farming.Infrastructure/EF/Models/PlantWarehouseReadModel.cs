
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantWarehouseReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }

        public ICollection<PlantWarehouseStateReadModel> States { get; set; }

        internal PlantWarehouseReadModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            States = new HashSet<PlantWarehouseStateReadModel>();
        }
    }
}
