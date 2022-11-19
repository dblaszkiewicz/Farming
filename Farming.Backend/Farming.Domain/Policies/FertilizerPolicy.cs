using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Land;

namespace Farming.Domain.Policies
{
    public sealed class FertilizerPolicy : IFertilizerPolicy
    {
        public bool IsEnoughFertilizerForWholeArea(Fertilizer fertilizer, LandArea area,
            FertilizerActionQuantity quantity) => area * fertilizer.RequiredAmountPerHectare >= quantity;
    }
}
