using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Policies
{
    public sealed class PlantWarehouseStatePolicy : IPlantWarehouseStatePolicy
    {
        public bool IsEnoughPlants(PlantWarehouseState state, PlantWarehouseQuantity quantity)
            => state.Quantity >= quantity;
    }
}
