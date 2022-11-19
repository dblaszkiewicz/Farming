using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Policies
{
    public interface IPlantPolicy
    {
        bool IsEnoughPlantForWholeArea(Plant plant, LandArea area, PlantActionQuantity quantity);
    }
}
