using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Plant;

namespace Farming.Domain.Factories
{
    public interface IPlantActionFactory
    {
        PlantAction Create(PlantId plantId, UserId userId, PlantActionQuantity quantity);
    }
}
