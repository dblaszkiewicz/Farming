
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideTypeReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PesticideReadModel> Pesticides { get; set; }
    }
}
