using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class StartNewSeasonAnotherActiveException : FarmingException
    {
        public StartNewSeasonAnotherActiveException() : base("Cannot start a new season, already exists another active season")
        {
        }
    }
}
