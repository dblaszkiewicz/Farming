using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.User
{
    public record UserLastName
    {
        public string Value { get; }

        public UserLastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserLastNameException();
            }

            Value = value;
        }

        public static implicit operator string(UserLastName lastName)
            => lastName.Value;

        public static implicit operator UserLastName(string lastName)
            => new(lastName);
    }
}
