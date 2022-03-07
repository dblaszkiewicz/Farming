using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantRequiredAmountPerHectare
    {
        public decimal Value { get; }

        public PlantRequiredAmountPerHectare(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPlantRequiredAmountPerHectareException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PlantRequiredAmountPerHectare requiredAmount)
            => requiredAmount.Value;

        public static implicit operator PlantRequiredAmountPerHectare(decimal requiredAmount)
            => new(requiredAmount);
    }
}
