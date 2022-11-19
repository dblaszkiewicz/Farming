
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerTypeReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<FertilizerReadModel> Fertilizers { get; set; }

        public FertilizerTypeReadModel()
        {

        }

        internal FertilizerTypeReadModel(string name, string description, List<FertilizerReadModel> fertilizers)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;

            Fertilizers = fertilizers;
        }
    }
}
