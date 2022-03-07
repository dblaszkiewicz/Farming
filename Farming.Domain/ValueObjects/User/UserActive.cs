
namespace Farming.Domain.ValueObjects.User
{
    public record UserActive
    {
        public bool Value { get; }

        public UserActive(bool value)
        {
            Value = value;
        }

        public static implicit operator bool(UserActive active)
            => active.Value;

        public static implicit operator UserActive(bool active)
            => new(active);
    }
}
