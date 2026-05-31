using OrderForLiveTest.Domain.Entities;

namespace OrderForLiveTest.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}