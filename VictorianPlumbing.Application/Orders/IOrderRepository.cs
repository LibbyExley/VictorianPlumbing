using VictorianPlumbing.Domain.Orders;

namespace VictorianPlumbing.Application.Orders;

public interface IOrderRepository
{
    Task<Order> CreateCustomerOrder(Order order);

}
