using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Season;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record SeasonChangeActive(Season season, SeasonActive seasonActive) : IDomainEvent;
}
