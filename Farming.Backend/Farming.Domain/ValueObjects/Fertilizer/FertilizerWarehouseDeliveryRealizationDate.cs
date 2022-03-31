
namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerWarehouseDeliveryRealizationDate
    {
        public DateTimeOffset Value { get; }

        public FertilizerWarehouseDeliveryRealizationDate()
        {
            Value = DateTimeOffset.UtcNow;
        }

        public FertilizerWarehouseDeliveryRealizationDate(DateTimeOffset value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset(FertilizerWarehouseDeliveryRealizationDate deliveryDate)
            => deliveryDate.Value;

        public static implicit operator FertilizerWarehouseDeliveryRealizationDate(DateTimeOffset deliveryDate)
            => new(deliveryDate);
    }
}
