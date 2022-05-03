using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyLandIdException : FarmingException
    {
        public EmptyLandIdException() : base("Land ID cannot be empty")
        {
        }
    }
}
