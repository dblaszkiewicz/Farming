
namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideWarehouseDeliveryRealizationDate
    {
        public DateTimeOffset Value { get; }

        public PesticideWarehouseDeliveryRealizationDate()
        {
            Value = DateTimeOffset.UtcNow;
        }

        public PesticideWarehouseDeliveryRealizationDate(DateTimeOffset value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset(PesticideWarehouseDeliveryRealizationDate deliveryDate)
            => deliveryDate.Value;

        public static implicit operator PesticideWarehouseDeliveryRealizationDate(DateTimeOffset deliveryDate)
            => new(deliveryDate);
    }
}
