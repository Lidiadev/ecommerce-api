using Application.Customers.CreateCustomer;
using Application.Customers.GetCustomer;
using MediatR;
using Application.Customers.GetCustomers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
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
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<CustomerDetailDTO> Get(long customerId)
        {
            return await Mediator.Send(new GetCustomerQuery { Id = customerId });
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<CustomerDTO>> Get()
        {
            return await Mediator.Send(new GetCustomersQuery());
        }

        [HttpPost("CreateCustomer")]
        public async Task<ActionResult<long>> Create(CreateCustomerCommand command)
        {
            var id = await Mediator.Send(command);

            _logger.LogInformation($"Customer {id} was created.");

            return id;
        }

        [HttpOptions]
        public IActionResult GetOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}
