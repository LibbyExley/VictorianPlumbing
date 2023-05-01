using VictorianPlumbing.Application.Orders;
using VictorianPlumbing.Domain.Customers;

namespace VictorianPlumbing.Application.Customers;

public class CustomerQueryService : ICustomerQueryService
{
    private ICustomerRepository _customerRepository;

    public CustomerQueryService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Customer> FindCustomerFromDTO(CustomerDTO customerDTO)
    {
        var customer = await _customerRepository.GetCustomerByEmail(customerDTO.EmailAddress);
        if (customer == null)
        {
            //if doesn't exist create new customer record
            customer = new Domain.Customers.Customer(
            Guid.NewGuid(),
            customerDTO.CustomerName,
                customerDTO.EmailAddress);
        }
        else
        {
            customer.UpdateName(customerDTO.CustomerName);
        }
        return customer;
    }
}

