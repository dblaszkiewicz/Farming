using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPesticideWarehouseDeliveryQuantityException : FarmingException
    {
        public decimal DeliveryQuantity { get; }
        public InvalidPesticideWarehouseDeliveryQuantityException(decimal value) : base($"Value '{value}' is invalid pesticide warehouse quantity")
        {
            DeliveryQuantity = value;
        }
    }
}
