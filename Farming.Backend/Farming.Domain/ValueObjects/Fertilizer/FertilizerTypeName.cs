
namespace Farming.Domain.ValueObjects.Fertilizer
{
    public record FertilizerTypeName
    {
        public string Value { get; }

        public FertilizerTypeName(string value)
        {
            Value = value;
        }

        public static implicit operator string(FertilizerTypeName name)
            => name.Value;

        public static implicit operator FertilizerTypeName(string name)
            => new(name);
    }
}
