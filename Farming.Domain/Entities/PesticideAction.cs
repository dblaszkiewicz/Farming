using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Entities
{
    public class PesticideAction
    {
        public PesticideActionId Id { get; }
        public PesticideId PesticideId { get; }
        public LandRealizationId LandRealizationId { get; }
        public UserId UserId { get; }
        public PesticideActionQuantity Quantity { get; }
        public PesticideActionRealizationDate RealizationDate { get; }

        public Pesticide Pesticide { get; }
        public LandRealization LandRealization { get; }
        public User User { get; }
    }
}
