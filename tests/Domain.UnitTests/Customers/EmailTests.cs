using Domain.Customers;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Domain.UnitTests.Customers
{
    public class EmailTests
    {
        [Test]
        public void Create_ShouldSetTheValue()
        {
            const string email = "test@gmail.com";

            var result = Email.Create(email);

            result.Value.Should().Be(email);
        }

        [Test]
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public void Create_ShouldThrowExceptionForInvalidEmail(string email)
        {
            FluentActions
                .Invoking(() => Email.Create(email))
                .Should()
                .Throw<Exception>()
                .WithMessage("Email should not be empty.");
        }

        [Test]
        [TestCase("email")]
        [TestCase("email@")]
        public void Create_ShouldThrowExceptionForInvalidEmailFormat(string email)
        {
            FluentActions
                .Invoking(() => Email.Create(email))
                .Should()
                .Throw<Exception>()
                .WithMessage("Email is invalid.");
        }

        [Test]
        public void ImplicitConversionToString_ShouldConvertToTheCorrectString()
        {
            const string emailAddress = "test@gmail.com";
            var email = Email.Create(emailAddress);

            var result = (string)email;

            result.Should().Be(emailAddress);
        }

        [Test]
        public void ExplicitConversionFromString_ShouldSetTheCorrectValue()
        {
            const string emailAddress = "test@gmail.com";

            var result = (Email)emailAddress;

            result.Value.Should().Be(emailAddress);
        }

        [Test]
        [TestCase("test@gmail.com", "test@gmail.com", true)]
        [TestCase("test@gmail.com", "TEST@gmail.com", true)]
        [TestCase("test@gmail.com", "abc@gmail.com", false)]
        public void Equals_ShouldReturnTheCorrectResult(string emailAddress1, string emailAddress2, bool expectedResult)
        {
            var email1 = Email.Create(emailAddress1);
            var email2 = Email.Create(emailAddress2);

            var result = email1 == email2;

            result.Should().Be(expectedResult);
        }
    }
}
