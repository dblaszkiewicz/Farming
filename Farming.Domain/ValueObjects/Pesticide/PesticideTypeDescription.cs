namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideTypeDescription
    {
        public string Value { get; }

        public PesticideTypeDescription(string value)
        {
            Value = value;
        }

        public static implicit operator string(PesticideTypeDescription description)
            => description.Value;

        public static implicit operator PesticideTypeDescription(string description)
            => new(description);
    }
}
