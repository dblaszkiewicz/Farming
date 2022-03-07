using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPesticideWarehouseDeliveryPriceException : FarmingException
    {
        public decimal DeliveryPrice { get; }

        public InvalidPesticideWarehouseDeliveryPriceException(decimal value) : base($"Value '{value}' is invalid pesticide warehouse delivery price")
        {
            DeliveryPrice = value;
        }
    }
}
