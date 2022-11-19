
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideTypeReadModel : BaseTenantReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PesticideReadModel> Pesticides { get; set; }

        public PesticideTypeReadModel()
        {

        }

        internal PesticideTypeReadModel(string name, string description, List<PesticideReadModel> pesticides)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;

            Pesticides = pesticides;
        }
    }
}
