using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderForLiveTest.Domain.Entities;

namespace OrderForLiveTest.Infrastructure.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CustomerName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Total)
                .HasPrecision(18, 2);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey(x => x.OrderId);
        }
    }
}