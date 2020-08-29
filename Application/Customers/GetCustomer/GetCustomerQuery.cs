using Application.Common.Exceptions;
using Domain.Customers;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerDetailDTO>
    {
        public long Id { get; set; }
    }

    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDetailDTO>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<CustomerDetailDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return new CustomerDetailDTO
            {
                Name = entity.Name,
                Email = entity.Email,
                Orders = entity.Orders
                        .Select(
                            o => new OrderDTO
                            {
                                OrderLines = o.OrderLines
                                            .Select(l => new OrderLineDTO
                                            {
                                                ProductId = l.ProductId,
                                                Price = l.Price,
                                                Quantity = l.Quantity
                                            })
                                            .ToList(),
                                TotalPrice = o.GetTotalPrice()
                            })
                        .ToList()
            };
        }
    }
}
