using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Orders
{
    public class Order : Entity
    {
        public DateTime CreatedDate { get; set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {
            _orderItems = new List<OrderItem>();
        }
    }
}
