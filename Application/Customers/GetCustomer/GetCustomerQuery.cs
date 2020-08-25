using Application.Common.Exceptions;
using Domain.Customers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.GetCustomer
{
    public class GetCustomerQuery : IRequest<CustomerDto>
    {
        public long Id { get; set; }
    }

    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return new CustomerDto
            {
                Name = entity.Name,
                Email = entity.Email
            };
        }
    }
}
