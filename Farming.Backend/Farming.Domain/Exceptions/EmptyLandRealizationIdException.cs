using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyLandRealizationIdException : FarmingException
    {
        public EmptyLandRealizationIdException() : base("Land realization ID cannot be empty.")
        {
        }
    }
}
