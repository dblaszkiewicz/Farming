using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPlantWarehouseStateIdException : FarmingException
    {
        public EmptyPlantWarehouseStateIdException() : base("Plant Warehouse State ID cannot be empty")
        {
        }
    }
}
