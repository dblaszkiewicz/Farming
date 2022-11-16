using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PlantAction : AggregateRoot<PlantActionId>
    {
        public PlantId PlantId { get; }
        public UserId UserId { get; }
        public LandRealizationId LandRealizationId { get; }
        public PlantActionQuantity Quantity { get; }
        public PlantActionRealizationDate RealizationDate { get; }

        public Plant Plant { get; }
        public User User { get; }
        public LandRealization LandRealization { get; }

        public PlantAction()
        {
        }

        public PlantAction(PlantId plantId, UserId userId, PlantActionQuantity quantity,
            PlantActionRealizationDate realizationDate)
        {
            Id = new PlantActionId(Guid.NewGuid());

            PlantId = plantId;
            UserId = userId;
            Quantity = quantity;
            RealizationDate = realizationDate;
        }
    }
}
