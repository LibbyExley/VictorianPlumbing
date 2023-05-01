using VictorianPlumbing.Domain.Customers;

namespace VictorianPlumbing.Domain.Orders;

public class OrderBuilder
{
    private readonly Order _order;

    public OrderBuilder(Guid id, DateTime timeCreated)
    {
        _order = new Order(id, timeCreated);
    }
    
    public OrderBuilder WithCustomer(Customer customer)
    {
        _order.AssignCustomer(customer);
        return this;
    }

    public OrderBuilder WithLines(IEnumerable<OrderLine> lines)
    {
        _order.SetLines(lines);
        return this;
    }

    public Order Build()
    {
        return _order;
    }
}