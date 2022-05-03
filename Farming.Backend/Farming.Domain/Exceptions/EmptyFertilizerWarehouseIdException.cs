using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyFertilizerWarehouseIdException : FarmingException
    {
        public EmptyFertilizerWarehouseIdException() : base("Fertilizer Warehouse ID cannot be empty")
        {
        }
    }
}
