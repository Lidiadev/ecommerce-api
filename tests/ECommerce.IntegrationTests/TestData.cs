using Application.Common.Interfaces;
using Domain.Customers;
using System.Threading.Tasks;

namespace ECommerce.IntegrationTests
{
    public static class TestData
    {
        public static void PopulateTestData(IECommerceDbContext dbContext)
        {
            dbContext.Customers.Add(new Customer(CustomerName.Create("John"), Email.Create("john@gmail.com")));
            dbContext.Customers.Add(new Customer(CustomerName.Create("Ana"), Email.Create("ana@gmail.com")));
            
            dbContext.SaveChanges();
        }
    }
}
