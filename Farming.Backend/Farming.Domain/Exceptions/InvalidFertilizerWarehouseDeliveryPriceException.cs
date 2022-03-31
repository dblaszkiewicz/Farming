using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidFertilizerWarehouseDeliveryPriceException : FarmingException
    {
        public decimal DeliveryPrice { get; }
        public InvalidFertilizerWarehouseDeliveryPriceException(decimal value) : base($"Value '{value}' is invalid fertilizer warehouse delivery price.")
        {
            DeliveryPrice = value;
        }
    }
}
