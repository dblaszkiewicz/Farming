
namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideActionRealizationDate
    {
        public DateTimeOffset Value { get; }

        public PesticideActionRealizationDate(DateTimeOffset value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset(PesticideActionRealizationDate realizationDate)
            => realizationDate.Value;

        public static implicit operator PesticideActionRealizationDate(DateTimeOffset realizationDate)
            => new(realizationDate);
    }
}
