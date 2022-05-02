using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class AuthenticationUserNotFound : FarmingException
    {
        public AuthenticationUserNotFound() : base("User with provided credentials do not exist!")
        {
        }
    }
}
