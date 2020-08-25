using Domain.Common;
using System;

namespace Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        private string _name;
        public virtual CustomerName Name 
        {
            get => (CustomerName)_name;
            private set => _name = value;
        }

        private string _email;
        public virtual Email Email
        {
            get => (Email)_email;
            private set => _email = value;
        }

        protected Customer()
        {
        }

        public Customer(CustomerName name, Email email)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
