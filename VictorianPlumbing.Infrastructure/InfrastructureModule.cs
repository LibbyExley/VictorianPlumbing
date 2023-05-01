using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VictorianPlumbing.Application.Customers;
using VictorianPlumbing.Application.Orders;
using VictorianPlumbing.Application.Products;
using VictorianPlumbing.Infrastructure.Context;
using VictorianPlumbing.Infrastructure.Repositories;

namespace VictorianPlumbing.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection RegisterInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            return services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Database"), 
                    x => x.MigrationsAssembly("VictorianPlumbing.Infrastructure"));
            });
        }
    }
}