using Domain.Customers;
using Domain.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.CreateOrder
{
    public class CreateOrderCommand : IRequest<long>
    {
        public long CustomerId { get; set; }

        public IEnumerable<OrderLineDTO> OrderLines { get; set; }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.CustomerId);

            if (customer == null)
                throw new Exception($"Customer {request.CustomerId} does not exist.");

            var entity = new Order(request.CustomerId);

            foreach(var orderLine in request.OrderLines)
            {
                entity.AddOrderLine(orderLine.ProductId, orderLine.Price, orderLine.Quantity);
            }

            await _orderRepository.AddAsync(entity);

            return entity.Id;
        }
    }
}
