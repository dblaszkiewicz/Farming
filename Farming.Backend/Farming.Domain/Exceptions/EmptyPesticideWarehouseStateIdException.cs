using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPesticideWarehouseStateIdException : FarmingException
    {
        public EmptyPesticideWarehouseStateIdException() : base("Pesticide Warehouse ID cannot be empty.")
        {
        }
    }
}
