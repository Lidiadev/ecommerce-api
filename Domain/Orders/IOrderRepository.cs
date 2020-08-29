using Domain.Common;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> AddAsync(Order Order);
    }
}
