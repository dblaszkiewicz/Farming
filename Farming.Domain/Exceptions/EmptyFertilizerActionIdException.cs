using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyFertilizerActionIdException : FarmingException
    {
        public EmptyFertilizerActionIdException() : base("Fertilizer action ID cannot be empty.")
        {
        }
    }
}
