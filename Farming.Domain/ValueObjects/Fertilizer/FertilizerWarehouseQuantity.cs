using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerWarehouseQuantity
    {
        public decimal Value { get; private set; }

        public FertilizerWarehouseQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidFertilizerWarehouseQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(FertilizerWarehouseQuantity quantity)
            => quantity.Value;

        public static implicit operator FertilizerWarehouseQuantity(decimal quantity)
            => new(quantity);

        public void Append(decimal value)
        {
            // TODO: walidacja + exception
            Value += value;
        }

        public void Spend(decimal value)
        {
            // TODO: walidacja + exception
            Value -= value;
        }
    }
}
