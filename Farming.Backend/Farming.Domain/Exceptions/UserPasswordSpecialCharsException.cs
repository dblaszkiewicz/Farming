using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class UserPasswordSpecialCharsException : FarmingException
    {
        public UserPasswordSpecialCharsException() : base("Password should contain At least one special character")
        {
        }
    }
}
