using Framework.Domain;

namespace Shop.Domain.Models.Customers;

public class Customer:AggregateRoot<Guid>
{
    public Customer(string mobile, string userName, string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        Mobile = mobile;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
    }
    public string Mobile { get;private set; }
    public string UserName { get;private set; }
    public string FirstName { get;private set; }
    public string LastName { get;private set; }
}