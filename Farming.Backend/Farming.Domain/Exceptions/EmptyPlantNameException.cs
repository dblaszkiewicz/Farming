using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPlantNameException : FarmingException
    {
        public EmptyPlantNameException() : base("Plant name cannot be empty")
        {
        }
    }
}
