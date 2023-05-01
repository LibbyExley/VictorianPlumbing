using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VictorianPlumbing.Domain.Customers;
using VictorianPlumbing.Domain.Orders;
using VictorianPlumbing.Domain.Products;

namespace VictorianPlumbing.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderLine> OrderLine { get; set; }
    public DbSet<Order> Orders { get; set; }
}
