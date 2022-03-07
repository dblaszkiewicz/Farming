using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPesticideActionQuantityException : FarmingException
    {
        public decimal ActionQuantity { get; }

        public InvalidPesticideActionQuantityException(decimal value) : base($"Value '{value}' is invalid pesticide action quantity.")
        {
            ActionQuantity = value;
        }
    }
}
