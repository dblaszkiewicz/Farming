using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.User;

namespace Farming.Domain.Factories
{
    public interface IPesticideActionFactory
    {
        PesticideAction Create(PesticideId pesticideId, UserId userId, PesticideActionQuantity quantity);
    }
}
