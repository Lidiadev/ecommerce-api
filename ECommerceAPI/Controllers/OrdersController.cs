using Application.Orders.CreateOrder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<long>> Create(CreateOrderCommand command)
        {
            var id = await Mediator.Send(command);

            _logger.LogInformation($"Order {id} was created.");

            return id;
        }
    }
}
