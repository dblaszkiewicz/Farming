using Farming.Domain.Entities;

namespace Farming.Domain.Policies
{
    public interface ILandPolicy
    {
        bool IsStatusSuitableForPlantAction(Land land);
    }
}
