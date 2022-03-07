using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerName
    {
        public string Value { get; }

        public FertilizerName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyFertilizerNameException();
            }

            Value = value;
        }

        public static implicit operator string(FertilizerName name)
            => name.Value;

        public static implicit operator FertilizerName(string name)
            => new(name);
    }
}
