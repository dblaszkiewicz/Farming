using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.User
{
    public record UserFirstName
    {
        public string Value { get; }

        public UserFirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserFirstNameException();
            }

            Value = value;
        }

        public static implicit operator string(UserFirstName firstName)
            => firstName.Value;

        public static implicit operator UserFirstName(string firstName)
            => new(firstName);
    }
}
