using Farming.Shared.Abstractions.Exceptions;

namespace Farming.Domain.Exceptions
{
    public class InvalidLandAreaException : FarmingException
    {
        public decimal LandArea { get; }
        public InvalidLandAreaException(decimal value) : base($"Value '{value}' is invalid land area.")
        {
            LandArea = value;
        }
    }
}
