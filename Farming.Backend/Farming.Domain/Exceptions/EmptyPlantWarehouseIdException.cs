using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPlantWarehouseIdException : FarmingException
    {
        public EmptyPlantWarehouseIdException() : base("Plant Warehouse ID cannot be empty.")
        {
        }
    }
}
