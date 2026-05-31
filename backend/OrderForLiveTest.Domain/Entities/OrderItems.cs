namespace OrderForLiveTest.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Guid OrderId { get; private set; }

        private OrderItem()
        {
        }

        public OrderItem(
            string productName,
            int quantity,
            decimal price)
        {
            Validate(productName, quantity, price);

            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public decimal GetTotal()
        {
            return Quantity * Price;
        }

        private static void Validate(
            string productName,
            int quantity,
            decimal price)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new Exception("Product name is required");

            if (quantity <= 0)
                throw new Exception("Quantity must be greater than zero");

            if (price <= 0)
                throw new Exception("Price must be greater than zero");
        }
    }
}