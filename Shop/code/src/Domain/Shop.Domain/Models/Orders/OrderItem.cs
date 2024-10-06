using Framework.Domain;
using Shop.Domain.Models.Products;

namespace Shop.Domain.Models.Orders;

public class OrderItem:Entity<long>
{
    public OrderItem(long productId, int count, double price, Guid orderId)
    {
        ProductId = productId;
        Count = count;
        Price = price;
        OrderId = orderId;
    }
    public long ProductId { get;private set; }
    public Product Product { get;private set; }
    public int Count { get;private  set; }
    public double Price { get;private set; }
    public Guid OrderId { get;private set; }
    public Order Order { get;private set; }
}