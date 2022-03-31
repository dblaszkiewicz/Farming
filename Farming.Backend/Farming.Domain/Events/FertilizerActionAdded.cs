using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record FertilizerActionAdded(LandRealization LandRealization, FertilizerAction FertilizerAction) : IDomainEvent;
}
