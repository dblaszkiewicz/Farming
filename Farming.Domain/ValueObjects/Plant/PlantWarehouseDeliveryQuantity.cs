using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantWarehouseDeliveryQuantity
    {
        public decimal Value { get; }

        public PlantWarehouseDeliveryQuantity(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPlantWarehouseDeliveryQuantityException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PlantWarehouseDeliveryQuantity quantity)
            => quantity.Value;

        public static implicit operator PlantWarehouseDeliveryQuantity(decimal quantity)
            => new(quantity);
    }
}
