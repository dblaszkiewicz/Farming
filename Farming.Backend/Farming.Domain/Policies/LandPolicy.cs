using Farming.Domain.Entities;

namespace Farming.Domain.Policies
{
    public class LandPolicy : ILandPolicy
    {
        public bool IsStatusSuitableForPlantAction(Land land)
            => land.Status.IsSuitableForPlantAction();
    }
}
