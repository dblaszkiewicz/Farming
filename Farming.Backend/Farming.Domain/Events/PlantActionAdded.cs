using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PlantActionAdded(LandRealization LandRealization, PlantAction PlantAction) : IDomainEvent;
}
