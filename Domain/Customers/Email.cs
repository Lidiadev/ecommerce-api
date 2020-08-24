﻿using Domain.Common;
using System;
using System.Text.RegularExpressions;

namespace Domain.Customers
{
    public sealed class Email : ValueObject<Email>
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            email = (email ?? string.Empty).Trim();

            if (email.Length == 0)
                throw new Exception("Email should not be empty.");

            if (!Regex.IsMatch(email, "^(.+)@(.+)$"))
                throw new Exception("Email is invalid.");

            return new Email(email);
        }

        protected override bool EqualsCore(Email other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}
