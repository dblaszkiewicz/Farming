using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyFertilizerWarehouseDeliveryIdException : FarmingException
    {
        public EmptyFertilizerWarehouseDeliveryIdException() : base("Fertilizer Action ID cannot be empty.")
        {
        }
    }
}
