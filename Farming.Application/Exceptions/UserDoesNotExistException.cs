using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class UserDoesNotExistException : FarmingException
    {
        public Guid UserId { get; set; }
        public UserDoesNotExistException(Guid userId) : base($"User with ID: '{userId}' does not exist")
        {
            UserId = userId;
        }
    }
}
