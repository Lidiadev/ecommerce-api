using Domain.Common;

namespace Domain.Customers
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public Email Email { get; set; }
    }
}
