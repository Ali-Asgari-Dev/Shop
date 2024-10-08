using Shop.Application.Dto.Requests;
using Shop.Application.Dto.Requests.Orders;

namespace Shop.Application.Contracts;

public interface IOrderService
{
    Task ApplyDiscount(OrderApplyDiscountRequestDto dto);
    Task<Guid> CreateOrder(CreateOrderRequestDto dto);
    Task AddItemToOrder(AddItemToOrderRequestDto dto);
    Task Paid(PaidOrderRequestDto dto);
}