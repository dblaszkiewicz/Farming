using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantActionQuantity
    {
        public decimal Value { get; }

        public PlantActionQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPlantActionQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PlantActionQuantity quantity)
            => quantity.Value;

        public static implicit operator PlantActionQuantity(decimal quantity)
            => new(quantity);
    }
}
