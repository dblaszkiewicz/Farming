using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class CurrentSeasonNotFoundException : FarmingException
    {
        public CurrentSeasonNotFoundException() : base("Season cannot be ended, there is no active season")
        {
        }
    }
}
