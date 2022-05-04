using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class UserNotActiveException : FarmingException
    {
        public UserNotActiveException() : base("Your account is not active")
        {
        }
    }
}
