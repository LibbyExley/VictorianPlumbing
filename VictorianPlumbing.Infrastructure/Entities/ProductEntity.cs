using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VictorianPlumbing.Domain.Products;

namespace VictorianPlumbing.Infrastructure.Entities;

public class ProductEntity : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Price).HasColumnType("Money") .IsRequired();
        builder.HasKey(p => p.ProductId);
    }
}
