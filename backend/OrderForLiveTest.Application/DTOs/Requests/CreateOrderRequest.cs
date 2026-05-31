namespace OrderForLiveTest.Application.DTOs.Requests
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; } = String.Empty;
        public List<CreateOrderItemRequest> Items { get; set; } = [];
    }
}
