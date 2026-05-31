using Microsoft.EntityFrameworkCore;
using OrderForLiveTest.Domain.Entities;
using OrderForLiveTest.Domain.Interfaces;
using OrderForLiveTest.Infrastructure.Data;

namespace OrderForLiveTest.Infrastructure.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(Order order)
        {
            await _context.Orders.AddAsync(order);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(x => x.Items)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return;

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }
    }
}