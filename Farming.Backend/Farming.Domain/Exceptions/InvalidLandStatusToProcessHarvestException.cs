using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidLandStatusToProcessHarvestException : FarmingException
    {
        public InvalidLandStatusToProcessHarvestException() : base("Niepoprawny status działki do przeprowadzenia zbioru.")
        {

        }
    }
}
