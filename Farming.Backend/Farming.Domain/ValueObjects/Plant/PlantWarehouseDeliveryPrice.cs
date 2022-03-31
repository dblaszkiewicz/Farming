using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantWarehouseDeliveryPrice
    {
        public decimal Value { get; }

        public PlantWarehouseDeliveryPrice(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidPlantWarehouseDeliveryPriceException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(PlantWarehouseDeliveryPrice price)
            => price.Value;

        public static implicit operator PlantWarehouseDeliveryPrice(decimal price)
            => new(price);
    }
}
