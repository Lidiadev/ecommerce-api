using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        private long _customerId;
        public virtual long CustomerId
        {
            get => _customerId;
            private set => _customerId = value;
        }

        public DateTime CreatedDate { get; private set; }

        private readonly List<OrderLine> _orderLines;
        public IReadOnlyCollection<OrderLine> OrderLines => _orderLines;

        protected Order()
        {
            _orderLines = new List<OrderLine>();
        }

        public Order(long customerId)
            : this()
        {
            CustomerId = customerId;
            CreatedDate = DateTime.UtcNow;
        }
            
        public void AddOrderLine(long productId, decimal price, int quantity)
        {
            var existingOrder = _orderLines.SingleOrDefault(o => o.ProductId == productId);

            if (existingOrder != null)
            {
                existingOrder.IncreaseQuantity(quantity);
            }
            else
            {
                var orderLine = new OrderLine(productId, price, quantity);
                _orderLines.Add(orderLine);
            }
        }

        public decimal GetTotalPrice()
        {
            return _orderLines.Sum(l => l.Quantity * l.Price);
        }
    }
}
