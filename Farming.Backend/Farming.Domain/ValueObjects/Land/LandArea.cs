using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.Land
{
    public record LandArea
    {
        public decimal Value { get; }

        public LandArea(decimal value)
        {
            if (value < 0)
            {
                throw new InvalidLandAreaException(value);
            }

            Value = value;
        }

        public static implicit operator decimal(LandArea area)
            => area.Value;

        public static implicit operator LandArea(decimal area)
            => new(area);
    }
}
