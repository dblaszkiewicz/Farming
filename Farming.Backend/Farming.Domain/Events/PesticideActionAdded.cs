using Farming.Domain.Entities;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record PesticideActionAdded(LandRealization LandRealization, PesticideAction PesticideAction) : IDomainEvent;
}
