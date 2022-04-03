
namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantWarehouseName
    {
        public string Value { get; }

        public PlantWarehouseName(string value)
        {
            Value = value;
        }

        public static implicit operator string(PlantWarehouseName name)
            => name.Value;

        public static implicit operator PlantWarehouseName(string name)
            => new(name);
    }
}
