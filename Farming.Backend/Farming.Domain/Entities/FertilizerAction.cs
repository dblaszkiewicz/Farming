using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerAction : Tenant
    {
        public FertilizerActionId Id { get; }
        public FertilizerId FertilizerId { get; }
        public LandRealizationId LandRealizationId { get; }
        public UserId UserId { get; }
        public FertilizerActionQuantity Quantity { get; }
        public FertilizerActionRealizationDate RealizationDate { get; }

        public Fertilizer Fertilizer { get; }
        public LandRealization LandRealization { get; }
        public User User { get; }

        internal FertilizerAction(FertilizerId fertilizerId, UserId userId, FertilizerActionQuantity quantity,
            FertilizerActionRealizationDate realizationDate)
        {
            Id = new FertilizerActionId(Guid.NewGuid());
            FertilizerId = fertilizerId;
            UserId = userId;
            Quantity = quantity;
            RealizationDate = realizationDate;
        }
    }
}
