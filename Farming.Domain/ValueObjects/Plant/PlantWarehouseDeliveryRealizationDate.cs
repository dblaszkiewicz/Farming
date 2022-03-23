
namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantWarehouseDeliveryRealizationDate
    {
        public DateTimeOffset Value { get; }

        public PlantWarehouseDeliveryRealizationDate()
        {
            Value = DateTimeOffset.UtcNow;
        }

        public PlantWarehouseDeliveryRealizationDate(DateTimeOffset value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset(PlantWarehouseDeliveryRealizationDate deliveryDate)
            => deliveryDate.Value;

        public static implicit operator PlantWarehouseDeliveryRealizationDate(DateTimeOffset deliveryDate)
            => new(deliveryDate);
    }
}
