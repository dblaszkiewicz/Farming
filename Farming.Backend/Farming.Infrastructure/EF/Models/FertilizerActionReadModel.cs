
namespace Farming.Infrastructure.EF.Models
{
    internal class FertilizerActionReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public Guid FertilizerId { get; set; }
        public Guid LandRealizationId { get; set; }
        public Guid UserId { get; set; }
        public decimal Quantity { get; set; }
        public DateTimeOffset RealizationDate { get; set; }

        public FertilizerReadModel Fertilizer { get; set; }
        public LandRealizationReadModel LandRealization { get; set; }
        public UserReadModel User { get; set; }
    }
}
