using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPesticideWarehouseDeliveryIdException : FarmingException
    {
        public EmptyPesticideWarehouseDeliveryIdException() : base("Pesticide Warehouse ID cannot be empty.")
        {
        }
    }
}
