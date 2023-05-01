using VictorianPlumbing.Domain.Customers;

namespace VictorianPlumbing.Application.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByEmail(string emailAddress);
}
