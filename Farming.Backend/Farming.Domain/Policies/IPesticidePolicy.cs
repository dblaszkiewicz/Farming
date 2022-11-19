using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Policies
{
    public interface IPesticidePolicy
    {
        bool IsEnoughPesticideForWholeArea(Pesticide pesticide, LandArea area, PesticideActionQuantity quantity);
    }
}
