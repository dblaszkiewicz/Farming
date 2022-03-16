
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerWarehouseReadModel
    {
        public Guid Id { get; set; }

        public ICollection<FertilizerWarehouseStateReadModel> States { get; set; }
    }
}
