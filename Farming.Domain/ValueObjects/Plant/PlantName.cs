using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Plant
{
    public record PlantName
    {
        public string Value { get; }

        public PlantName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyPlantNameException();
            }

            Value = value;
        }

        public static implicit operator string(PlantName name)
            => name.Value;

        public static implicit operator PlantName(string name)
            => new(name);
    }
}
