﻿using Farming.Domain.Exceptions;

namespace Farming.Domain.ValueObjects.User
{
    public record UserLogin
    {
        public string Value { get; }

        public UserLogin(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyUserLoginException();
            }

            if (value.Length < 4)
            {
                throw new UserLoginTooShortException();
            } 

            Value = value.ToLower();
        }

        public static implicit operator string(UserLogin login)
            => login.Value;

        public static implicit operator UserLogin(string login)
            => new(login);
    }
}
