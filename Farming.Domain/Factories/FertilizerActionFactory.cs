using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public class FertilizerActionFactory : IFertilizerActionFactory
    {
        public FertilizerAction Create(FertilizerId fertilzierId, UserId userId, FertilizerActionQuantity quantity)
        {
            var realizationDate = new FertilizerActionRealizationDate(DateTimeOffset.UtcNow);

            return new FertilizerAction(fertilzierId, userId, quantity, realizationDate);
        }
    }
}
