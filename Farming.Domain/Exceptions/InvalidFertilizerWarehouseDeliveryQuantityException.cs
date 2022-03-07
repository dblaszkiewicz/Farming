using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidFertilizerWarehouseDeliveryQuantityException : FarmingException
    {
        public decimal DeliveryQuantity { get; }

        public InvalidFertilizerWarehouseDeliveryQuantityException(decimal value) : base($"Value '{value}' is invalid fertilizer delivery quatity")
        {
            DeliveryQuantity = value;
        }
    }
}
