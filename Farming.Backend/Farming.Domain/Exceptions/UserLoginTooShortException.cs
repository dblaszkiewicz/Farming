using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class UserLoginTooShortException : FarmingException
    {
        public UserLoginTooShortException() : base("Password should not be less than 4 character")
        {
        }
    }
}
