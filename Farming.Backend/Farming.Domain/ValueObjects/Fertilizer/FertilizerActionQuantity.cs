using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerActionQuantity
    {
        public decimal Value { get; }

        public FertilizerActionQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidFertilizerActionQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(FertilizerActionQuantity actionQuantity)
            => actionQuantity.Value;

        public static implicit operator FertilizerActionQuantity(decimal actionQuantity)
            => new(actionQuantity);
    }
}
