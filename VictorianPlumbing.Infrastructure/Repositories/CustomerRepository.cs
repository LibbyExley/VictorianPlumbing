using Microsoft.EntityFrameworkCore;
using VictorianPlumbing.Application.Customers;
using VictorianPlumbing.Domain.Customers;
using VictorianPlumbing.Infrastructure.Context;

namespace VictorianPlumbing.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customer?> GetCustomerByEmail(string emailAddress)
    {
        return await _dbContext.Customers.SingleOrDefaultAsync(c => c.EmailAddress == emailAddress);
    }

}
