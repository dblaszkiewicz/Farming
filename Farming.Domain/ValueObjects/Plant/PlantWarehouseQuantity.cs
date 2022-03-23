using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantWarehouseQuantity
    {
        public decimal Value { get; }

        public PlantWarehouseQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPlantWarehouseQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PlantWarehouseQuantity quantity)
            => quantity.Value;

        public static implicit operator PlantWarehouseQuantity(decimal quantity)
            => new(quantity);
    }
}
