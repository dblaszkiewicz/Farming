using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideWarehouseQuantity
    {
        public decimal Value { get; }

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
    }
}
