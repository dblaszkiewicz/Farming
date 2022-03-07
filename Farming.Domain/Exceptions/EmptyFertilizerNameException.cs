using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyFertilizerNameException : FarmingException
    {
        public EmptyFertilizerNameException() : base("Fertilizer name cannot be empty.")
        {
        }
    }
}
