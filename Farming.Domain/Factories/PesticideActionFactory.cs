using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public class PesticideActionFactory : IPesticideActionFactory
    {
        public PesticideAction Create(PesticideId pesticideId, UserId userId, PesticideActionQuantity quantity)
        {
            var realizationDate = new PesticideActionRealizationDate(DateTimeOffset.UtcNow);

            return new PesticideAction(pesticideId, userId, quantity, realizationDate);
        }
    }
}
