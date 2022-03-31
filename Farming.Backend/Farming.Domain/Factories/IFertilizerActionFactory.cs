using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public interface IFertilizerActionFactory
    {
        FertilizerAction Create(FertilizerId fertilzierId, UserId userId, FertilizerActionQuantity quantity);
    }
}
