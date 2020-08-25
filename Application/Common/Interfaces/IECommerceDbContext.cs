using Domain.Common;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IECommerceDbContext : IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
