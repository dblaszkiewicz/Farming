using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPesticideNameException : FarmingException
    {
        public EmptyPesticideNameException() : base("Pesticide name cannot be empty")
        {
        }
    }
}
