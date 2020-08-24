using Domain.Common;
using System;

namespace Domain.Customers
{
    public class Customer : Entity
    {
        private readonly string _name;
        public CustomerName Name => (CustomerName)_name;

        private readonly string _email;
        public Email Email => (Email)_email;

        public Customer(CustomerName name, Email email)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
