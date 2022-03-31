using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideRequiredAmountPerHectare
    {
        public decimal Value { get; }

        public PesticideRequiredAmountPerHectare(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPesticideRequiredAmountPerHectareException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PesticideRequiredAmountPerHectare requiredAmount)
            => requiredAmount.Value;

        public static implicit operator PesticideRequiredAmountPerHectare(decimal requiredAmount)
            => new(requiredAmount);
    }
}
