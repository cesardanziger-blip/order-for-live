using OrderForLiveTest.Application.DTOs.Requests;
using OrderForLiveTest.Application.Interfaces;
using OrderForLiveTest.Domain.Entities;
using OrderForLiveTest.Domain.Interfaces;

namespace OrderForLiveTest.Application.Services
{
    public class OrderService(IOrderRepository repository): IOrderService
    {
        private readonly IOrderRepository _repository = repository;

        public async Task CreateAsync(CreateOrderRequest request)
        {
            var items = request.Items
                .Select(x => new OrderItem(
                    x.ProductName,
                    x.Quantity,
                    x.Price))
                .ToList();

            var order = new Order(
                request.CustomerName,
                items);

            await _repository.CreateAsync(order);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}