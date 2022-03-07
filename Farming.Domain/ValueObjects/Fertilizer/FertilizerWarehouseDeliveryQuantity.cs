using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerWarehouseDeliveryQuantity
    {
        public decimal Value { get; }

        public FertilizerWarehouseDeliveryQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidFertilizerWarehouseQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(FertilizerWarehouseDeliveryQuantity quantity)
            => quantity.Value;

        public static implicit operator FertilizerWarehouseDeliveryQuantity(decimal quantity)
            => new(quantity);
    }
}
