using Domain.Common;
using System.Threading.Tasks;

namespace Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> GetAsync(long customerId);
    }
}
