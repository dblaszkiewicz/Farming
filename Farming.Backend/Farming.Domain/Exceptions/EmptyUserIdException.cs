using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyUserIdException : FarmingException
    {
        public EmptyUserIdException() : base("User ID cannot be empty")
        {
        }
    }
}
