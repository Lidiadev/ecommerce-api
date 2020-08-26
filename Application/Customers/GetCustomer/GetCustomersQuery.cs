using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.GetCustomer
{
    public class GetCustomersQuery : IRequest<IReadOnlyCollection<CustomerDto>>
    {
    }

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IReadOnlyCollection<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<IReadOnlyCollection<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var entities = await _customerRepository.GetAllAsync();

            return entities.Select(c => new CustomerDto
                {
                    Name = c.Name,
                    Email = c.Email
                })
                .ToList();
        }
    }
}
