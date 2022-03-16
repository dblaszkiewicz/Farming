
namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerTypeDescription
    {
        public string Value { get; }

        public FertilizerTypeDescription(string value)
        {
            Value = value;
        }

        public static implicit operator string(FertilizerTypeDescription description)
            => description.Value;

        public static implicit operator FertilizerTypeDescription(string description)
            => new(description);
    }
}
