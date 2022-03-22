using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideWarehouseQuantity
    {
        public decimal Value { get; private set; }

        public PesticideWarehouseQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPesticideWarehouseQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PesticideWarehouseQuantity quantity)
            => quantity.Value;

        public static implicit operator PesticideWarehouseQuantity(decimal quantity)
            => new(quantity);

        public void Append(decimal value)
        {
            // TODO walidacja
            Value += value;
        }
    }
}
