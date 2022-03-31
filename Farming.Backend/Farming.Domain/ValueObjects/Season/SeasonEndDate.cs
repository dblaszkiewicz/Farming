
namespace Farming.Domain.ValueObjects.Season
{
    public record SeasonEndDate
    {
        public DateTimeOffset? Value { get; }

        public SeasonEndDate(DateTimeOffset? value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset?(SeasonEndDate deliveryDate)
            => deliveryDate.Value;

        public static implicit operator SeasonEndDate(DateTimeOffset? deliveryDate)
            => new(deliveryDate);
    }
}
