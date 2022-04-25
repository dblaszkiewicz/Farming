
namespace Farming.Domain.ValueObjects.User
{
    public record UserCreated
    {
        public DateTimeOffset? Value { get; }

        public UserCreated(DateTimeOffset? value)
        {
            Value = value;
        }

        public static implicit operator DateTimeOffset?(UserCreated created)
            => created.Value;

        public static implicit operator UserCreated(DateTimeOffset? created)
            => new(created);
    }
}
