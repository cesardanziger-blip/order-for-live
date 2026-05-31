using OrderForLiveTest.Application.DTOs.Requests;
using OrderForLiveTest.Domain.Entities;

namespace OrderForLiveTest.Application.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderRequest request);
        Task<List<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
