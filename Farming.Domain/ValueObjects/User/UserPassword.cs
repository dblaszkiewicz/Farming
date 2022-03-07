using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.User
{
    public record UserPassword
    {
        public string Value { get; }

        public UserPassword(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserPasswordException();
            }

            Value = value;
        }

        public static implicit operator string(UserPassword login)
            => login.Value;

        public static implicit operator UserPassword(string login)
            => new(login);
    }
}
