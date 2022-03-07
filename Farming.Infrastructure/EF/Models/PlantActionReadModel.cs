
namespace Farming.Infrastructure.EF.Models
{
    internal class PlantActionReadModel
    {
        public Guid Id { get; set; }
        public Guid PlantId { get; set; }
        public Guid UserId { get; set; }
        public Guid LandRealizationId { get; set; }
        public decimal Quantity { get; set; }
        public DateTimeOffset DateRealization { get; set; }

        public PlantReadModel Plant { get; set; }
        public UserReadModel User { get; set; }
        public LandRealizationReadModel LandRealization { get; set; }
    }
}
