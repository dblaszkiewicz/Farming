using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class FertilizerWarehouseStateNotFoundException : FarmingException
    {
        public Guid FertilzierId { get; set; }
        public Guid FertilizerWarehouseId { get; set; }
        public FertilizerWarehouseStateNotFoundException(Guid fertilizerId, Guid fertilizerWarehouseId) :
            base($"State with fertilzier ID: '{fertilizerId}' on fertilizer warehouse with ID: '{fertilizerWarehouseId}' was not found")
        {
            FertilzierId = fertilizerId;
            FertilizerWarehouseId = fertilizerWarehouseId;
        }
    }
}
