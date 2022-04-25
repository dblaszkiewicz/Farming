using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Application.Exceptions
{
    public class NoMoreActiveAdministratorException : FarmingException
    {
        public NoMoreActiveAdministratorException() : base("There are no more active administrators")
        {
        }
    }
}
