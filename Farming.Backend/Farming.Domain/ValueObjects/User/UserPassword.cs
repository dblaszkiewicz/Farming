using Farming.Domain.Exceptions;
using System.Text.RegularExpressions;

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

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            //var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasNumber.IsMatch(value))
            {
                throw new UserPasswordNumberException();
            }

            if (!hasUpperChar.IsMatch(value))
            {
                throw new UserPasswordUpperCaseCharsException();
            }

            if (!hasMiniMaxChars.IsMatch(value))
            {
                throw new UserPasswordMinMaxCharsException();
            }

            if (!hasLowerChar.IsMatch(value))
            {
                throw new UserPasswordLowerCaseCharsException();
            }

            //if (!hasSymbols.IsMatch(value))
            //{
            //    throw new UserPasswordSpecialCharsException();
            //}

            Value = value;
        }

        public static implicit operator string(UserPassword login)
            => login.Value;

        public static implicit operator UserPassword(string login)
            => new(login);
    }
}
