
namespace Farming.Infrastructure.EF.Models
{
    internal class PesticideActionReadModel : BaseReadModel
    {
        public Guid Id { get; set; }
        public Guid PesticideId { get; set; }
        public Guid LandRealizationId { get; set; }
        public Guid UserId { get; set; }
        public decimal Quantity { get; set; }
        public DateTimeOffset RealizationDate { get; set; }

        public PesticideReadModel Pesticide { get; set; }
        public LandRealizationReadModel LandRealization { get; set; }
        public UserReadModel User { get; set; }
    }
}
