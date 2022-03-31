using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EndSeasonNotActiveException : FarmingException
    {
        public EndSeasonNotActiveException() : base("It is impossible to end not active season")
        {
        }
    }
}
