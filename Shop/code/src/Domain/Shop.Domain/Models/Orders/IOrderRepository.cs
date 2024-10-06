namespace Shop.Domain.Models.Orders;

public interface IOrderRepository
{
    Task<Order?> LastOrderByCustomerId(Guid customerId);
}