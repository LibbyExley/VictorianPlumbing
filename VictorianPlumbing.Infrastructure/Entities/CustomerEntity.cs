using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VictorianPlumbing.Domain.Customers;

namespace VictorianPlumbing.Infrastructure.Entities;

public class CustomerEntity : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.CustomerId).IsRequired();
        builder.Property(c => c.CustomerName).IsRequired();
        builder.Property(c => c.EmailAddress).IsRequired();
        builder.HasKey(c => c.CustomerId);
        builder.HasIndex(c => c.EmailAddress).IsUnique();
    }
}
