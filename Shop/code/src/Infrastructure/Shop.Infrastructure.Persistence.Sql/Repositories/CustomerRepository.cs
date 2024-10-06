using Shop.Domain.Models.Customers;

namespace Shop.Infrastructure.Persistence.Sql.Repositories;

public class CustomerRepository(DataBaseContext dbContext) : ICustomerRepository
{
    public async Task AddCustomer(Customer customer)
        => await dbContext.Customers.AddAsync(customer);

    public async Task Save() => await dbContext.SaveChangesAsync();
}