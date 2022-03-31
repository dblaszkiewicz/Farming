using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyUserLoginException : FarmingException
    {
        public EmptyUserLoginException() : base("User login cannot be empty.")
        {
        }
    }
}
