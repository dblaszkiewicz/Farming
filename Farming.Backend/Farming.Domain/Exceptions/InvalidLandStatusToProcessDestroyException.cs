using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidLandStatusToProcessDestroyException : FarmingException
    {
        public InvalidLandStatusToProcessDestroyException() : base("Invalid land status to process destroy")
        {

        }
    }
}
