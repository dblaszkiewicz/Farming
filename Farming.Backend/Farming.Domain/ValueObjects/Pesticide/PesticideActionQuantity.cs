using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideActionQuantity
    {
        public decimal Value { get; }

        public PesticideActionQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPesticideActionQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PesticideActionQuantity actionQuantity)
            => actionQuantity.Value;

        public static implicit operator PesticideActionQuantity(decimal actionQuantity)
            => new(actionQuantity);
    }
}
