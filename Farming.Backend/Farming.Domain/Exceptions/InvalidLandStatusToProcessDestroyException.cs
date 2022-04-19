using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidLandStatusToProcessDestroyException : FarmingException
    {
        public InvalidLandStatusToProcessDestroyException() : base("Niepoprawny status działki do popsucia zbioru.")
        {

        }
    }
}
