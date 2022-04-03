using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Factories
{
    public interface IPesticideActionFactory
    {
        PesticideAction Create(PesticideId pesticideId, UserId userId, PesticideActionQuantity quantity);
    }
}
