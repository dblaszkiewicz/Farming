using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidFertilizerActionQuantityException : FarmingException
    {
        public decimal FertilizerActionQuantity { get; }

        public InvalidFertilizerActionQuantityException(decimal value) : base($"Value '{value}' is invalid fertilizer action quantity.")
        {
            FertilizerActionQuantity = value;
        }
    }
}
