using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPlantWarehouseDeliveryPriceException : FarmingException
    {
        public decimal DeliveryPrice { get; }
        public InvalidPlantWarehouseDeliveryPriceException(decimal value) : base($"Value '{value}' is invalid warehouse delivery price.")
        {
            DeliveryPrice = value;
        }
    }
}
