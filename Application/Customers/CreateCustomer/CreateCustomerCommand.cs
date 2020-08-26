using Domain.Customers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<long>
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerName = CustomerName.Create(request.Name);
            var email = Email.Create(request.Email);

            var entity = new Customer(customerName, email);

            await _customerRepository.AddAsync(entity);

            return entity.Id;
        }
    }
}
