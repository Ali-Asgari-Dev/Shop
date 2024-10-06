using Shop.Application.Contracts;
using Shop.Application.Dto.Requests;
using Shop.Domain.Models.Orders;
using Shop.Domain.Services;

namespace Shop.Application.Services;

public class OrderService(IOrderRepository orderRepository,IUnitOfDiscountCalculatorService unitOfDiscountCalculatorService) : IOrderService
{
    public async Task ApplyDiscount(OrderApplyDiscountRequestDto dto)
    {
        var order = await orderRepository.FindById(dto.Id);
        if (order is null) throw new ApplicationException("سفارش یافت نشد");
        order.ApplyDiscount(unitOfDiscountCalculatorService);
        await orderRepository.Save();
    }
}