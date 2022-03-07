using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyFertilizerIdException : FarmingException
    {
        public EmptyFertilizerIdException() : base("Fertilizer ID cannot be empty.")
        {
        }
    }
}
