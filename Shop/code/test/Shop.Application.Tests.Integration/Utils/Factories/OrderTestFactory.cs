using Shop.Domain.Models.Orders;

namespace Shop.Application.Tests.Integration.Utils.Factories;

public class OrderTestFactory
{
    public static Order New(Guid customerId)
    {
        var order = new Order(customerId);
        return order;
    }
}