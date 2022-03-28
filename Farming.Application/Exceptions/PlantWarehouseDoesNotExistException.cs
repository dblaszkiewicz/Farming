using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class PlantWarehouseDoesNotExistException : FarmingException
    {
        public Guid PlantWarehouseId { get; set; }
        public PlantWarehouseDoesNotExistException(Guid plantWarehouseId) : base($"Plant Warehouse with ID: '{plantWarehouseId}' does not exist")
        {
            PlantWarehouseId = plantWarehouseId;
        }
    }
}
