using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class NotEnoughPesticideForPlantWholeAreaException : FarmingException
    {
        public NotEnoughPesticideForPlantWholeAreaException() : base("There is not enough pesticide quantity for realization a whole land area")
        {
        }
    }
}
