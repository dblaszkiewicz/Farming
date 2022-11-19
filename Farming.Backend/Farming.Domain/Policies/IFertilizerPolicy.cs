using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Land;

namespace Farming.Domain.Policies
{
    public interface IFertilizerPolicy
    {
        bool IsEnoughFertilizerForWholeArea(Fertilizer fertilizer, LandArea area, 
            FertilizerActionQuantity quantity);
    }
}
