using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class FertilizerWarehouseNotFoundException : FarmingException
    {
        public Guid FertilizerWarehouseId { get; set; }
        public FertilizerWarehouseNotFoundException(Guid fertilizerWarehouseId) : base($"Fertilizer Warehouse with ID: '{fertilizerWarehouseId}' was not found")
        {
            FertilizerWarehouseId = fertilizerWarehouseId;
        }
    }
}
