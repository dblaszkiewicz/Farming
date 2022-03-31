using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerWarehouseDeliveryPrice
    {
        public decimal Value { get; }

        public FertilizerWarehouseDeliveryPrice(decimal value)
        {
            if (value <= 0)
            {
                throw new InvalidFertilizerWarehouseDeliveryPriceException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(FertilizerWarehouseDeliveryPrice price)
            => price.Value;

        public static implicit operator FertilizerWarehouseDeliveryPrice(decimal price)
            => new(price);
    }
}
