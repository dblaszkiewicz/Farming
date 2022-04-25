using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class UserPasswordNumberException : FarmingException
    {
        public UserPasswordNumberException() : base("Password should contain At least one numeric value")
        {
        }
    }
}
