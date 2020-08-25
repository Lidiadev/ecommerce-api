using Domain.Common;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IECommerceDbContext : IUnitOfWork
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
