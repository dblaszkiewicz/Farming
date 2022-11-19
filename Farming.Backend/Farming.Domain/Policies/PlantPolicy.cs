using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Policies
{
    public sealed class PlantPolicy : IPlantPolicy
    {
        public bool IsEnoughPlantForWholeArea(Plant plant, LandArea area, PlantActionQuantity quantity)
            => quantity >= area * plant.RequiredAmountPerHectare;
    }
}
