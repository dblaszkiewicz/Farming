
namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerDescription
    {
        public string Value { get; }

        public FertilizerDescription(string value)
        {
            Value = value;
        }

        public static implicit operator string(FertilizerDescription description)
            => description.Value;

        public static implicit operator FertilizerDescription(string description)
            => new(description);
    }
}
