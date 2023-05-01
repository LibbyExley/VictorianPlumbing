using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VictorianPlumbing.Application.Customers;
using VictorianPlumbing.Application.Orders;
using VictorianPlumbing.Application.Products;

namespace VictorianPlumbing.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection RegisterApplicationModule(this IServiceCollection services)
        {
            services.AddTransient<ICustomerQueryService , CustomerQueryService>();
            services.AddTransient<IProductQueryService , ProductQueryService>();
            services.AddTransient<IOrderService , OrderService>();
            services.AddTransient<IValidator<NewOrderDTO>, OrderValidator>();
            return services;
        }
    }
}