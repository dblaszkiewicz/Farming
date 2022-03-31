using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidFertilizerRequiredAmountPerHectareException : FarmingException
    {
        public decimal RequiredAmountPerHectare { get; }

        public InvalidFertilizerRequiredAmountPerHectareException(decimal value) : base($"Value '{value}' is invalid fertilizer required amount per hectare.")
        {
            RequiredAmountPerHectare = value;
        }
    }
}
