using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class NotEnoughFertilizerForPlantWholeAreaException : FarmingException
    {
        public NotEnoughFertilizerForPlantWholeAreaException() : base("There is not enough fertilizer quantity for fertilize a whole land area")
        {
        }
    }
}
