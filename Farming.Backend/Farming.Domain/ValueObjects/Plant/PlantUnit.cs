
namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantUnit
    {
        public string Value { get; }

        public PlantUnit(string value)
        {
            Value = value;
        }

        public static implicit operator string(PlantUnit unit)
            => unit.Value;

        public static implicit operator PlantUnit(string unit)
            => new(unit);
    }
}
