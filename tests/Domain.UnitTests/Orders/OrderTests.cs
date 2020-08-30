using Domain.Orders;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Domain.UnitTests.Orders
{
    public class OrderTests
    {
        [Test]
        public void AddOrderItem_ShouldAddANewOrderItem_WhenThereIsNoExistingOrderForAProductId()
        {
            const int customerId = 1;
            const decimal price = 100;
            const int quantity = 2;
            const long productId = 1000;
            var order = new Order(customerId);

            order.AddOrderLine(productId, price, quantity);

            order.OrderLines.Count.Should().Be(1);

            var orderLine = order.OrderLines.FirstOrDefault();
            orderLine.Price.Should().Be(price);
            orderLine.Quantity.Should().Be(quantity);
            orderLine.ProductId.Should().Be(productId);
        }

        [Test]
        public void AddOrderItem_ShouldIncreaseQuantity_WhenThereIsAnExistingOrderLineForAProductId()
        {
            const int customerId = 1;
            const decimal price = 100;
            const long productId = 1000;
            var order = new Order(customerId);
            order.AddOrderLine(productId, price, 10);

            order.AddOrderLine(productId, price, 20);

            order.OrderLines.Count.Should().Be(1);

            var orderLine = order.OrderLines.FirstOrDefault();
            orderLine.Price.Should().Be(price);
            orderLine.Quantity.Should().Be(30);
            orderLine.ProductId.Should().Be(productId);
        }

        [Test]
        public void GetTotalPrice_ShouldReturnThePriceForTheEntireOrder()
        {
            const int customerId = 1;
            var order = new Order(customerId);
            order.AddOrderLine(1, 1000, 10);
            order.AddOrderLine(2, 2000, 20);
            order.AddOrderLine(3, 300, 2);
            order.AddOrderLine(3, 300, 4);

            var result = order.GetTotalPrice();

            result.Should().Be(51800);
        }

        [Test]
        public void GetTotalPrice_ShouldReturnZeroWhenThereIsNoOrder()
        {
            const int customerId = 1;
            var order = new Order(customerId);

            var result = order.GetTotalPrice();

            result.Should().Be(0);
        }
    }
}
