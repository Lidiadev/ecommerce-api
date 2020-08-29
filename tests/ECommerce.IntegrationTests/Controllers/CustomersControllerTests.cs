using Application.Customers.GetCustomer;
using Application.Customers.GetCustomers;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.IntegrationTests.Controllers
{
    public class CustomersControllerTests : TestBase
    {
        [Test]
        public async Task GetCustomers_ShouldReturnSuccessAndCorrectContentType()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/customers");

            // Assert
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IReadOnlyCollection<CustomerDTO>>(stringResponse);
            customers.Should().Contain(c => c.Name == "John");
            customers.Should().Contain(c => c.Name == "Ana");
        }

        [Test]
        public async Task GetCustomerById_ShouldReturnSuccessAndCorrectContentType()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("/customers/1");

            // Assert
            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerDetailDTO>(stringResponse);
            customer.Name.Should().Be("John");
            customer.Email.Should().Be("john@gmail.com");
        }
    }
}
