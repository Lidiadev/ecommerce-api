namespace Application.Orders.CreateOrder
{
    public class OrderLineDTO
    {
        public long ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
