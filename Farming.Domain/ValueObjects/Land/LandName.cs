using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Land
{
    public record LandName
    {
        public string Value { get; }

        public LandName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyLandNameException();
            }

            Value = value;
        }

        public static implicit operator string(LandName name)
            => name.Value;

        public static implicit operator LandName(string name)
            => new(name);
    }
}
