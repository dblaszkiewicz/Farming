using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerRequiredAmountPerHectare
    {
        public decimal Value { get; }

        public FertilizerRequiredAmountPerHectare(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidFertilizerRequiredAmountPerHectareException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(FertilizerRequiredAmountPerHectare requiredAmount)
            => requiredAmount.Value;

        public static implicit operator FertilizerRequiredAmountPerHectare(decimal requiredAmount)
            => new(requiredAmount);
    }
}
