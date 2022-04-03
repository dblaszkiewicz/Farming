using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;

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
