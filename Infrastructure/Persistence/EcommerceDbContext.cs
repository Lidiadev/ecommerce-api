using Application.Common.Interfaces;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class ECommerceDbContext : DbContext, IECommerceDbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ECommerceDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
