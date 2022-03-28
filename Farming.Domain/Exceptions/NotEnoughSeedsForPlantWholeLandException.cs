using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class NotEnoughSeedsForPlantWholeLandException : FarmingException
    {
        public NotEnoughSeedsForPlantWholeLandException() : base("There is not enough seeds quantity for plant a whole land")
        {
        }
    }
}
