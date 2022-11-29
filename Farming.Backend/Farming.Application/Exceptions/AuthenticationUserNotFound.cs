using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class AuthenticationUserNotFoundException : FarmingException
    {
        public AuthenticationUserNotFoundException() : base("User with provided credentials do not exist")
        {
        }
    }
}
