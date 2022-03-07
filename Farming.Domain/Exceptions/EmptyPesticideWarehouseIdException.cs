using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPesticideWarehouseIdException : FarmingException
    {
        public EmptyPesticideWarehouseIdException() : base("Pesticide Warehouse ID cannot be empty.")
        {
        }
    }
}
