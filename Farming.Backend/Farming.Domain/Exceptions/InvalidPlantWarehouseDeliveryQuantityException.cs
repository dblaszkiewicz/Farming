using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPlantWarehouseDeliveryQuantityException : FarmingException
    {
        public decimal DeliveryQuantity { get; }

        public InvalidPlantWarehouseDeliveryQuantityException(decimal value) : base($"Value '{value}' is invalid plant warehouse delivery quantity.")
        {
            DeliveryQuantity = value;
        }

    }
}
