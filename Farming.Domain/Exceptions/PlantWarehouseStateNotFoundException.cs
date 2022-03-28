using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class PlantWarehouseStateNotFoundException : FarmingException
    {
        public Guid PlantId { get; set; }
        public Guid PlantWarehouseId { get; set; }
        public PlantWarehouseStateNotFoundException(Guid plantId, Guid plantWarehouseId) : 
            base($"State with plant ID: '{plantId}' on plant warehouse with ID: '{plantWarehouseId}' was not found")
        {
            PlantId = plantId;
            PlantWarehouseId = plantWarehouseId;
        }
    }
}
