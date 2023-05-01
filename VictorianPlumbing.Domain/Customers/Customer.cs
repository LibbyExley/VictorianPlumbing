using VictorianPlumbing.Domain.Orders;

namespace VictorianPlumbing.Domain.Customers;

public class Customer
{
    public Customer(Guid customerId, string customerName, string emailAddress)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        EmailAddress = emailAddress;
    }

    public Guid CustomerId { get; init; }
    public string CustomerName { get; private set; }
    public string EmailAddress { get; private set; }
    public ICollection<Order> Orders { get; set; }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        CustomerName = name;
    }
}
