using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class UserNotFoundException : FarmingException
    {
        public Guid UserId { get; set; }
        public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
        {
            UserId = userId;
        }
    }
}
