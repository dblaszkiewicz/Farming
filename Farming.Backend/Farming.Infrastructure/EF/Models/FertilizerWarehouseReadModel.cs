
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerWarehouseReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<FertilizerWarehouseStateReadModel> States { get; set; }

        internal FertilizerWarehouseReadModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;

            States = new HashSet<FertilizerWarehouseStateReadModel>();
        }
    }
}
