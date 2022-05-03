using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Api.Auth
{
    public class AuthorizationException : FarmingException
    {
        public AuthorizationException(string message) : base(message)
        {
        }
    }
}
