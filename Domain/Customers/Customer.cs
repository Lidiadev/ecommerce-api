using Domain.Common;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private readonly IList<Order> _orders;
        public virtual IReadOnlyCollection<Order> Orders => _orders.ToList();

        protected Customer()
        {
            _orders = new List<Order>();
        }

        public Customer(CustomerName name, Email email)
            : this()
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
