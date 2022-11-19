using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Pesticide;

namespace Farming.Domain.Policies
{
    public sealed class PesticidePolicy : IPesticidePolicy
    {
        public bool IsEnoughPesticideForWholeArea(Pesticide pesticide, LandArea area, PesticideActionQuantity quantity)
            => area * pesticide.RequiredAmountPerHectare >= quantity;
    }
}
