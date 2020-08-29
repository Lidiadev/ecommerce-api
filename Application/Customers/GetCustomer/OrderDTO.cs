using System.Collections.Generic;

namespace Application.Customers.GetCustomer
{
    public class OrderDTO
    {
        public IReadOnlyCollection<OrderLineDTO> OrderLines { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
