namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerActionRealizationDate
    {
        public DateTimeOffset Value { get; }

        public FertilizerActionRealizationDate(DateTimeOffset value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset(FertilizerActionRealizationDate realizationDate)
            => realizationDate.Value;

        public static implicit operator FertilizerActionRealizationDate(DateTimeOffset realizationDate)
            => new(realizationDate);
    }
}
