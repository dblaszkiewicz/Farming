using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class NotEnoughSeedsForPlantWholeAreaException : FarmingException
    {
        public NotEnoughSeedsForPlantWholeAreaException() : base("There is not enough seeds quantity for plant a whole land area")
        {
        }
    }
}
