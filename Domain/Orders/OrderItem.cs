using Domain.Common;
using System;

namespace Domain.Orders
{
    public class OrderItem : Entity
    {
        public decimal Price { get; private set; }

        private OrderItem()
        {
        }

        public OrderItem(decimal price)
        {
            if (price < 0)
                throw new InvalidOperationException();

            Price = price;
        }
    }
}
