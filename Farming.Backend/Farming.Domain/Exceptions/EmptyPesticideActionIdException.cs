using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPesticideActionIdException : FarmingException
    {
        public EmptyPesticideActionIdException() : base("Pesticide Action ID cannot be empty.")
        {
        }
    }
}
