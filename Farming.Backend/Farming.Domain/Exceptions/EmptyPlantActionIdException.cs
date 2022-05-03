using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPlantActionIdException : FarmingException
    {
        public EmptyPlantActionIdException() : base("Plant Action ID cannot be empty")
        {
        }
    }
}
