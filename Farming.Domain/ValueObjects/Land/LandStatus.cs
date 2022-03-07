
namespace Farming.Domain.ValueObjects.Land
{
    public record LandStatus
    {
        public int Value { get; }

        public LandStatus(int value)
        {
            Value = value;
        }

        public static implicit operator int(LandStatus status)
            => status.Value;

        public static implicit operator LandStatus(int status)
            => new(status);
    }
}
