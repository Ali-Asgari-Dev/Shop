namespace Shop.Domain.Models.Orders;

public interface IOrderRepository
{
    Task<Order?> LastOrderByCustomerId(Guid customerId);
    Task<Order?> FindById(Guid id);
    Task Save();
    Task CreateOrder(Order order);
}