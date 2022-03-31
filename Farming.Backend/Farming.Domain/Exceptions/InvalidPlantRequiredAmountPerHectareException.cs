using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPlantRequiredAmountPerHectareException : FarmingException
    {
        public decimal RequiredAmountPerHectare { get; }

        public InvalidPlantRequiredAmountPerHectareException(decimal value) : base($"Value '{value}' is invalid plant required amount per hectare.")
        {
            RequiredAmountPerHectare = value;
        }
    }
}
