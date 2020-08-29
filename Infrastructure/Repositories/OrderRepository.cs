using Application.Common.Interfaces;
using Domain.Common;
using Domain.Orders;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IECommerceDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public OrderRepository(IECommerceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> AddAsync(Order order)
        {
            var entity = await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();

            return entity.Entity;
        }
    }
}
