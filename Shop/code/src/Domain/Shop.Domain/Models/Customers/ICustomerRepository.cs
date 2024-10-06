namespace Shop.Domain.Models.Customers;

public interface ICustomerRepository
{
    Task AddCustomer(Customer customer);
    Task Save();
}