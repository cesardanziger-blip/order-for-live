namespace OrderForLiveTest.Application.DTOs.Requests
{
    public class CreateOrderItemRequest
    {
        public string ProductName { get; set; } = String.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
