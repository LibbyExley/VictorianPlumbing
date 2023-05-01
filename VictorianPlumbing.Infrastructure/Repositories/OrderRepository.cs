using VictorianPlumbing.Application.Orders;
using VictorianPlumbing.Domain.Orders;
using VictorianPlumbing.Infrastructure.Context;

namespace VictorianPlumbing.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> CreateCustomerOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }
}
