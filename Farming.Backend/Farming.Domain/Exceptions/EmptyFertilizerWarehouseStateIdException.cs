using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    internal class EmptyFertilizerWarehouseStateIdException : FarmingException
    {
        public EmptyFertilizerWarehouseStateIdException() : base("Fertilizer Warehouse State Id cannot be empty")
        {
        }
    }
}
