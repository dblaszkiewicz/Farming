using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public interface IPlantActionFactory
    {
        PlantAction Create(PlantId plantId, UserId userId, PlantActionQuantity quantity);
    }
}
