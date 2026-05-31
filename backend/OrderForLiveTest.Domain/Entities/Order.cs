using OrderForLiveTest.Domain.Enums;

namespace OrderForLiveTest.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string CustomerName { get; private set; }
        public decimal Total { get; private set; }
        public Status Status { get; private set; } = Status.Pending;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public List<OrderItem> Items { get; private set; } = [];

        private Order()
        {
        }

        public Order(
            string customerName,
            List<OrderItem> items)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new Exception("Customer name is required");

            if (items == null || items.Count == 0)
                throw new Exception("Order must have at least one item");

            CustomerName = customerName;

            Items = items;

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            Total = Items.Sum(x => x.GetTotal());
        }

        public void Approve()
        {
            Status = Status.Aproved;
        }
    }
}