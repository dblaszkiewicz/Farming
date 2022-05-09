
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideWarehouseReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PesticideWarehouseStateReadModel> States { get; }

        internal PesticideWarehouseReadModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            States = new HashSet<PesticideWarehouseStateReadModel>();
        }
    }
}
