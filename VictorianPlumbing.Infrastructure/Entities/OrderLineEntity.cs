using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VictorianPlumbing.Domain.Orders;

namespace VictorianPlumbing.Infrastructure.Entities;

public class OrderLineEntity : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.Property(o => o.Id).IsRequired();
        builder.Property(o => o.Quantity).IsRequired();
        builder.HasOne(o => o.Product).WithMany(p => p.OrderLines).IsRequired();
        builder.HasKey(o => o.Id);
    }
}
