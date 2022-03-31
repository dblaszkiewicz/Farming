
namespace Farming.Domain.ValueObjects.Season
{
    public record SeasonActive
    {
        public bool Value { get; }

        public SeasonActive(bool value)
        {
            Value = value;
        }

        public static implicit operator bool(SeasonActive active)
            => active.Value;

        public static implicit operator SeasonActive(bool active)
            => new(active);

        public bool IsActive()
        {
            return Value;
        }
    }
}
