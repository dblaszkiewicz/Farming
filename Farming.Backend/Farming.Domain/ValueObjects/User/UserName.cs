using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.User
{
    public record UserName
    {
        public string Value { get; }

        public UserName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserFirstNameException();
            }

            Value = value;
        }

        public static implicit operator string(UserName name)
            => name.Value;

        public static implicit operator UserName(string name)
            => new(name);
    }
}
