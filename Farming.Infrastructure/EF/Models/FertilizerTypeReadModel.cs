
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerTypeReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<FertilizerReadModel> Fertilizers { get; set; }
    }
}
