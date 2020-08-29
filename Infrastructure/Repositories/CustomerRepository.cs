using Application.Common.Interfaces;
using Domain.Common;
using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IECommerceDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public CustomerRepository(IECommerceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            var entity = (await _context.Customers.AddAsync(customer)).Entity;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> GetAsync(long customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task<IReadOnlyCollection<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByEmailAsync(Email email)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Email == email); 
        }
    }
}
