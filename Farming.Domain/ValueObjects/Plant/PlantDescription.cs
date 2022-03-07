
namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantDescription
    {
        public string Value { get; }

        public PlantDescription(string value)
        {
            Value = value;
        }

        public static implicit operator string(PlantDescription description)
            => description.Value;

        public static implicit operator PlantDescription(string description)
            => new(description);
    }
}
