using Application.Customers.CreateCustomer;
using Application.Customers.GetCustomer;
using Application.Customers.GetCustomers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly ILogger<CustomersController> _logger;

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
