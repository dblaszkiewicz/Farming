using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class UserPasswordMinMaxCharsException : FarmingException
    {
        public UserPasswordMinMaxCharsException() : base("Password should not be less than 6 or greater than 12 characters")
        {
        }
    }
}
