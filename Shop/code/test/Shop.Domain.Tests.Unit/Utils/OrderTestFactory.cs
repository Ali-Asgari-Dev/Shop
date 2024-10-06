using Shop.Domain.Models.Orders;

namespace Shop.Domain.Tests.Unit.Utils;

public class OrderTestFactory
{
    public static Order NewWithItem()
    {
          var order = new Order(Guid.NewGuid());
        order.AddItem(1,1,10000);
        return order;
    }
}