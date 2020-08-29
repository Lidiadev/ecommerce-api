using Domain.Common;
using System;

namespace Domain.Orders
{
    public class OrderLine : Entity
    {
        public long ProductId { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        private OrderLine()
        {
        }

        public OrderLine(long productId, decimal price, int quantity)
        {
            if (price <= 0)
                throw new InvalidOperationException("Invalid price.");

            if (quantity <= 0)
                throw new InvalidOperationException("Invalid quantity.");

            if (productId <= 0)
                throw new InvalidOperationException("Invalid product id.");

            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new InvalidOperationException("Invalid quantity.");

            Quantity += quantity;
        }
    }
}
