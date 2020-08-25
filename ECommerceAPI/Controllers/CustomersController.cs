using Application.Customers.CreateCustomer;
using Application.Customers.GetCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<CustomerDto> Get(long id)
        {
            return await Mediator.Send(new GetCustomerQuery { Id = id });
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<CustomerDto>> Get()
        {
            return await Mediator.Send(new GetCustomersQuery());
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create(CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
