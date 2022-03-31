using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class EmptyPlantNameException : FarmingException
    {
        public EmptyPlantNameException() : base("Plank name cannot be empty.")
        {
        }
    }
}
