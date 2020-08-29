using Domain.Customers;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Domain.UnitTests.Customers
{
    class CustomerNameTests
    {
        [Test]
        public void Create_ShouldSetTheValue()
        {
            const string name = "John";

            var result = CustomerName.Create(name);

            result.Value.Should().Be(name);
        }

        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public void Create_ShouldThrowExceptionForInvalidCustomerName(string name)
        {
            FluentActions
                .Invoking(() => CustomerName.Create(name))
                .Should()
                .Throw<Exception>()
                .WithMessage("Customer name should not be empty.");
        }

        [Test]
        public void Create_ShouldThrowExceptionForTooLongCustomerName()
        {
            var name = new string('A', 310);

            FluentActions
                .Invoking(() => CustomerName.Create(name))
                .Should()
                .Throw<Exception>()
                .WithMessage("Customer name is too long.");
        }

        [Test]
        public void ImplicitConversionToString_ShouldConvertToTheCorrectString()
        {
            const string name = "John";
            var customerName = CustomerName.Create(name);

            var result = (string)customerName;

            result.Should().Be(name);
        }

        [Test]
        public void ExplicitConversionFromString_ShouldSetTheCorrectValue()
        {
            const string name = "John";

            var result = (CustomerName)name;

            result.Value.Should().Be(name);
        }

        [Test]
        [TestCase("john", "John", true)]
        [TestCase("john", "JOHN", true)]
        [TestCase("John", "Ana", false)]
        public void Equals_ShouldReturnTheCorrectResult(string name1, string name2, bool expectedResult)
        {
            var customerName1 = CustomerName.Create(name1);
            var customerName2 = CustomerName.Create(name2);

            var result = customerName1 == customerName2;

            result.Should().Be(expectedResult);
        }
    }
}