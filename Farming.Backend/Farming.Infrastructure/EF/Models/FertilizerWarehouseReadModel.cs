
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerWarehouseReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }

        public ICollection<FertilizerWarehouseStateReadModel> States { get; set; }

        internal FertilizerWarehouseReadModel(string name, Guid tenantId)
        {
            Id = Guid.NewGuid();
            Name = name;
            TenantId = tenantId;

            States = new HashSet<FertilizerWarehouseStateReadModel>();
        }
    }
}
