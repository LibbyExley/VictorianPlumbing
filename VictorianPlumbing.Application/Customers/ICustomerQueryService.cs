using VictorianPlumbing.Application.Orders;
using VictorianPlumbing.Domain.Customers;

namespace VictorianPlumbing.Application.Customers;

public interface ICustomerQueryService
{
    Task<Customer> FindCustomerFromDTO(CustomerDTO customerDTO);
}
