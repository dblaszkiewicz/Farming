using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidPesticideRequiredAmountPerHectareException : FarmingException
    {
        public decimal RequiredAmountPerHectare { get; }

        public InvalidPesticideRequiredAmountPerHectareException(decimal value) : base($"Value '{value}' is invalid fertilizer required amount per hectare.")
        {
            RequiredAmountPerHectare = value;
        }
    }
}
