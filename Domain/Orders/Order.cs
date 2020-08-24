using System;
using System.Collections.Generic;

namespace Domain.Orders
{
    public class Order
    {
        public DateTime CreatedDate { get; set; }

        public ICollection<OrderItem> OrderItems;

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
