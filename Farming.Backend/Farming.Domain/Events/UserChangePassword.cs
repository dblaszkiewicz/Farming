using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Events
{
    public record UserChangePassword(User user, UserPassword password) : IDomainEvent;
}
