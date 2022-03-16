using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideAction : AggregateRoot<PesticideActionId>
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
