using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidFertilizerWarehouseQuantityException : FarmingException
    {
        public decimal WarehouseQuantity { get; }

        public InvalidFertilizerWarehouseQuantityException(decimal value) : base($"Value '{value}' is invalid warehouse quantity.")
        {
            WarehouseQuantity = value;
        }
    }
}
