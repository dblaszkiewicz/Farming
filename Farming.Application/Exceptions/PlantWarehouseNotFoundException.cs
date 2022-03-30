using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PlantWarehouseNotFoundException : FarmingException
    {
        public Guid PlantWarehouseId { get; set; }
        public PlantWarehouseNotFoundException(Guid plantWarehouseId) : base($"Plant Warehouse with ID: '{plantWarehouseId}' was not found")
        {
            PlantWarehouseId = plantWarehouseId;
        }
    }
}
