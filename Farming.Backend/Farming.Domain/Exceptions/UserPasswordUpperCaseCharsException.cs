using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class UserPasswordUpperCaseCharsException : FarmingException
    {
        public UserPasswordUpperCaseCharsException() : base("Password should contain At least one upper case letter")
        {
        }
    }
}
