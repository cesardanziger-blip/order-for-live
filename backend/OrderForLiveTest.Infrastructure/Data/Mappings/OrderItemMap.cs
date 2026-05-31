using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderForLiveTest.Domain.Entities;

namespace OrderForLiveTest.Infrastructure.Data.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.Property(x => x.OrderId)
                .IsRequired();
        }
    }
}