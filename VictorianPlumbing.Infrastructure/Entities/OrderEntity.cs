using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VictorianPlumbing.Domain.Orders;

namespace VictorianPlumbing.Infrastructure.Entities;

public class OrderEntity : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.Id).IsRequired();
        builder.Property(o => o.TimeCreated).IsRequired();
        builder.HasOne(o => o.Customer).WithMany(c => c.Orders).IsRequired();
        builder.HasMany(o => o.Lines).WithOne(l => l.Order).IsRequired();
        builder.HasKey(o => o.Id);
    }
}
