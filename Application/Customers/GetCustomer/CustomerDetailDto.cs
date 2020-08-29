using System.Collections.Generic;

namespace Application.Customers.GetCustomer
{
    public class CustomerDetailDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public IReadOnlyCollection<OrderDTO> Orders{ get; set; }
    }
}
