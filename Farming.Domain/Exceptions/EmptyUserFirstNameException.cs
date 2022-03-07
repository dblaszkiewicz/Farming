using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyUserFirstNameException : FarmingException
    {
        public EmptyUserFirstNameException() : base("User first name cannot be empty.")
        {
        }
    }
}
