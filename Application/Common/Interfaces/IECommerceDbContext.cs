using Domain.Common;
using Domain.Customers;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IECommerceDbContext : IUnitOfWork
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
    }
}
