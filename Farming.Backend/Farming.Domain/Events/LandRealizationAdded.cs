using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record LandRealizationAdded(Season Season, LandRealization LandRealization) : IDomainEvent;
}
