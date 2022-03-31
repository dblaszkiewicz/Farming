using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyUserLastNameException : FarmingException
    {
        public EmptyUserLastNameException() : base("User last name cannot be empty.")
        {
        }
    }
}
