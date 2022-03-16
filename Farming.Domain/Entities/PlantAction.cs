using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantAction : AggregateRoot<PlantActionId>
    {
        public PlantActionId Id { get; }
        public PlantId PlantId { get; }
        public UserId UserId { get; }
        public LandRealizationId LandRealizationId { get; }
        public PlantActionQuantity Quantity { get; }
        public PlantActionRealizationDate RealizationDate { get; }

        public Plant Plant { get; }
        public User User { get; }
        public LandRealization LandRealization { get; }
    }
}
