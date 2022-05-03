using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPlantIdException : FarmingException
    {
        public EmptyPlantIdException() : base("Plant ID cannot be empty")
        {
        }
    }
}
