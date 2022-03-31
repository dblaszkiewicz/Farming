
namespace Farming.Domain.ValueObjects.Plant
{
    public class PlantActionRealizationDate
    {
        public DateTimeOffset Value { get; }

        public PlantActionRealizationDate(DateTimeOffset value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset(PlantActionRealizationDate deliveryDate)
            => deliveryDate.Value;

        public static implicit operator PlantActionRealizationDate(DateTimeOffset deliveryDate)
            => new(deliveryDate);
    }
}
