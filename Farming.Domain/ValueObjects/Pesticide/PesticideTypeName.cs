namespace Farming.Domain.ValueObjects.Pesticide
{
    public record PesticideTypeName
    {
        public string Value { get; }

        public PesticideTypeName(string value)
        {
            Value = value;
        }

        public static implicit operator string(PesticideTypeName name)
            => name.Value;

        public static implicit operator PesticideTypeName(string name)
            => new(name);
    }
}
