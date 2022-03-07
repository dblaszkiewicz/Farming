
namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideDescription
    {
        public string Value { get; }

        public PesticideDescription(string value)
        {
            Value = value;
        }

        public static implicit operator string(PesticideDescription description)
            => description.Value;

        public static implicit operator PesticideDescription(string description)
            => new(description);
    }
}
