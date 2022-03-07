using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPlantActionQuantityException : FarmingException
    {
        public decimal ActionQuantity { get; }
        public InvalidPlantActionQuantityException(decimal value) : base($"Value '{value}' is invalid plant action quantity.")
        {
            ActionQuantity = value;
        }
    }
}
