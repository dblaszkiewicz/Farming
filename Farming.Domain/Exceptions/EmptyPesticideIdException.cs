using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPesticideIdException : FarmingException
    {
        public EmptyPesticideIdException() : base("Pesticide ID cannot be empty.")
        {
        }
    }
}
