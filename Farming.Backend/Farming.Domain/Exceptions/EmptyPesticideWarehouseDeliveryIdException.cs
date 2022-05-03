using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPesticideWarehouseDeliveryIdException : FarmingException
    {
        public EmptyPesticideWarehouseDeliveryIdException() : base("Pesticide Warehouse Delivery ID cannot be empty")
        {
        }
    }
}
