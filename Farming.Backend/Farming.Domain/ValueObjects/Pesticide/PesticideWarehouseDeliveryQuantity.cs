using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideWarehouseDeliveryQuantity
    {
        public decimal Value { get; }

        public PesticideWarehouseDeliveryQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPesticideWarehouseDeliveryQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PesticideWarehouseDeliveryQuantity quantity)
            => quantity.Value;

        public static implicit operator PesticideWarehouseDeliveryQuantity(decimal quantity)
            => new(quantity);
    }
}
