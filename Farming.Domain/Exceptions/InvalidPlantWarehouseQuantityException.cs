using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPlantWarehouseQuantityException : FarmingException
    {
        public decimal PlantWarehouseQuantity { get; }
        public InvalidPlantWarehouseQuantityException(decimal value) : base($"Value '{value}' is invalid plant warehouse quantity.")
        {
            PlantWarehouseQuantity = value;
        }
    }
}
