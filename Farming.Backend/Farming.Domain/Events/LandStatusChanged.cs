using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Land;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record LandStatusChanged(Land land, LandStatus landStatus) : IDomainEvent;
}
