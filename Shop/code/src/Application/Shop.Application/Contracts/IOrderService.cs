using Shop.Application.Dto.Requests;

namespace Shop.Application.Contracts;

public interface IOrderService
{
    Task ApplyDiscount(OrderApplyDiscountRequestDto dto);
}