using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class ActiveSeasonDoesNotExistException : FarmingException
    {
        public ActiveSeasonDoesNotExistException() : base("No active season")
        {
        }
    }
}
