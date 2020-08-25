using AutoMapper;
using Domain.Customers;
using MediatR;
using System;
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
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetAsync(request.Id);

            if (entity == null)
            {
                throw new Exception($"Customer not found {request.Id}");
            }

            return new CustomerDto
            {
                Name = entity.Name,
                Email = entity.Email
            };
        }
    }
}
