
namespace Farming.Domain.ValueObjects.Land
{
    public record LandClass
    {
        public string Value { get; }

        public LandClass(string value)
        {
            Value = value;
        }

        public static implicit operator string(LandClass status)
            => status.Value;

        public static implicit operator LandClass(string status)
            => new(status);
    }
}
