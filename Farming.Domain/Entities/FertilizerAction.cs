using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class FertilizerAction : AggregateRoot<FertilizerActionId>
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
    }
}
