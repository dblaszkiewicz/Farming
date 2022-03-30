using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class ActiveSeasonNotFoundException : FarmingException
    {
        public ActiveSeasonNotFoundException() : base("No active season")
        {
        }
    }
}
