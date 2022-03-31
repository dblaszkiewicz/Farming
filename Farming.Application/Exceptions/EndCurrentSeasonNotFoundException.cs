using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class EndCurrentSeasonNotFoundException : FarmingException
    {
        public EndCurrentSeasonNotFoundException() : base("Season cannot be ended, there is no active season")
        {
        }
    }
}
