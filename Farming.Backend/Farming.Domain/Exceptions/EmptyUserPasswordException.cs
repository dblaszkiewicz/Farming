using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    internal class EmptyUserPasswordException : FarmingException
    {
        public EmptyUserPasswordException() : base("User password cannot be empty.")
        {
        }
    }
}
