
namespace Farming.Domain.ValueObjects.Season
{
    public record SeasonStartDate
    {
        public DateTimeOffset Value { get; }

        public SeasonStartDate(DateTimeOffset value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset(SeasonStartDate deliveryDate)
            => deliveryDate.Value;

        public static implicit operator SeasonStartDate(DateTimeOffset deliveryDate)
            => new(deliveryDate);
    }
}
