using Domain.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.GetCustomers
{
    public class GetCustomersQuery : IRequest<IReadOnlyCollection<CustomerDTO>>
    {
    }

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IReadOnlyCollection<CustomerDTO>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<IReadOnlyCollection<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var entities = await _customerRepository.GetAllAsync();

            return entities.Select(c => new CustomerDTO
            {
                    Name = c.Name,
                    Email = c.Email
                })
                .ToList();
        }
    }
}
