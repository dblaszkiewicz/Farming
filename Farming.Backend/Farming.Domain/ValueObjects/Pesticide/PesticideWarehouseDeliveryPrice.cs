using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideWarehouseDeliveryPrice
    {
        public decimal Value { get; }

        public PesticideWarehouseDeliveryPrice(decimal value)
        {
            if (value <= 0)
            {
                throw new InvalidPesticideWarehouseDeliveryPriceException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PesticideWarehouseDeliveryPrice price)
            => price.Value;

        public static implicit operator PesticideWarehouseDeliveryPrice(decimal price)
            => new(price);
    }
}
