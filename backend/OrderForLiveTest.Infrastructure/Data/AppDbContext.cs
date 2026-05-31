using Microsoft.EntityFrameworkCore;
using OrderForLiveTest.Domain.Entities;

namespace OrderForLiveTest.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    }
}
