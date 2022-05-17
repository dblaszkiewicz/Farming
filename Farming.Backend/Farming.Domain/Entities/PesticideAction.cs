using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideAction : AggregateRoot<PesticideActionId>
    {
        public PesticideId PesticideId { get; }
        public LandRealizationId LandRealizationId { get; }
        public UserId UserId { get; }
        public PesticideActionQuantity Quantity { get; }
        public PesticideActionRealizationDate RealizationDate { get; }

        public Pesticide Pesticide { get; }
        public LandRealization LandRealization { get; }
        public User User { get; }

        public PesticideAction()
        {
        }

        public PesticideAction(PesticideId pesticideId, UserId userId, PesticideActionQuantity quantity, 
            PesticideActionRealizationDate realizationDate)
        {
            Id = new PesticideActionId(Guid.NewGuid());

            PesticideId = pesticideId;
            UserId = userId;
            Quantity = quantity;
            RealizationDate = realizationDate;
        }
    }
}
