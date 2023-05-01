using VictorianPlumbing.Domain.Customers;

namespace VictorianPlumbing.Domain.Orders;

public class Order
{
    public Order(Guid id, DateTime timeCreated)
    {
        Id = id;
        TimeCreated = timeCreated;
    }

    public Guid Id { get; init; }
    public DateTime TimeCreated { get; init; }
    public Customer Customer { get; private set; }
    public IEnumerable<OrderLine> Lines { get; private set; }
    public decimal OrderTotal => Lines.Sum(l => l.LineTotal);

    public void AssignCustomer(Customer customer)
    {
        Customer = customer;
    }

    public void SetLines(IEnumerable<OrderLine> lines)
    {
        if (!lines.Any())
        {
            throw new ArgumentException("An order must have lines");
        }

        Lines = lines.ToList();
    }
}
