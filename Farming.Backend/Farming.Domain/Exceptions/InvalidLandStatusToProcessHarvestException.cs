using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidLandStatusToProcessHarvestException : FarmingException
    {
        public InvalidLandStatusToProcessHarvestException() : base("Invalid land status to process harvest")
        {

        }
    }
}
