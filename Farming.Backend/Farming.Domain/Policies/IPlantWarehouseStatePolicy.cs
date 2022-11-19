using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Policies
{
    public interface IPlantWarehouseStatePolicy
    {
        bool IsEnoughPlants(PlantWarehouseState state, PlantWarehouseQuantity quantity);
    }
}
