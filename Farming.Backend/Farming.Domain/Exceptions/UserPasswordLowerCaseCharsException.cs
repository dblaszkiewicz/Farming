using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class UserPasswordLowerCaseCharsException : FarmingException
    {
        public UserPasswordLowerCaseCharsException() : base("Password should contain At least one lower case letter")
        {
        }
    }
}
