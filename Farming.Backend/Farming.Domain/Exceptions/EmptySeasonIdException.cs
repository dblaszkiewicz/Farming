using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptySeasonIdException : FarmingException
    {
        public EmptySeasonIdException() : base("Season ID cannot be empty")
        {
        }
    }
}
