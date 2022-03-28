using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class BadLandStatusForPlantActionException : FarmingException
    {
        public BadLandStatusForPlantActionException() : base("Land has a bad status for perform a plant action")
        {
        }
    }
}
