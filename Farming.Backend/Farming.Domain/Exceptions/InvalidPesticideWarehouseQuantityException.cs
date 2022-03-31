using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPesticideWarehouseQuantityException : FarmingException
    {
        public decimal WarehouseQuantity { get; }

        public InvalidPesticideWarehouseQuantityException(decimal value) : base($"Value '{value}' is invalid pesticide warehouse quantity")
        {
            WarehouseQuantity = value;
        }
    }
}
