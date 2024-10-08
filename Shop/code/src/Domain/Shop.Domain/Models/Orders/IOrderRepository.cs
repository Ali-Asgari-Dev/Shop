namespace Shop.Domain.Models.Orders;

public interface IOrderRepository
{
    Task<Order?> LastOrderByCustomerId(Guid customerId);
    Task<Order?> GetIncludeItemById(Guid id);
    Task<Order?> FindById(Guid id);
    Task Save();
    Task CreateOrder(Order order);
}