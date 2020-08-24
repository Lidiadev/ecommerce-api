﻿using Domain.Common;
using System;

namespace Domain.Customers
{
    public sealed class CustomerName : ValueObject<CustomerName>
    {
        public string Value { get; }

        private CustomerName(string value)
        {
            Value = value;
        }

        public static CustomerName Create(string customerName)
        {
            customerName = (customerName ?? string.Empty).Trim();

            if (customerName.Length == 0)
                throw new Exception("Customer name should not be empty.");

            if (customerName.Length > 300)
                throw new Exception("Customer name is too long.");

            return new CustomerName(customerName);
        }

        protected override bool EqualsCore(CustomerName other)
        {
            return Value.Equals(other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(CustomerName customerName)
        {
            return customerName.Value;
        }

        public static explicit operator CustomerName(string customerName)
        {
            return Create(customerName);
        }
    }
}
