using Shop.Application.Contracts;
using Shop.Application.Dto.Requests.Orders;
using Shop.Application.Mappers;
using Shop.Domain.Models.Orders;
using Shop.Domain.Services;

namespace Shop.Application.Services;

public class OrderService(
    IOrderRepository orderRepository,
    IProductDomainService productDomainService,
    IUnitOfDiscountCalculatorDomainService unitOfDiscountCalculatorDomainService) : IOrderService
{
    public async Task ApplyDiscount(OrderApplyDiscountRequestDto dto)
    {
        var order = await orderRepository.GetIncludeItemById(dto.Id);
        if (order is null) throw new ApplicationException("سفارش یافت نشد");
        order.ApplyDiscount(unitOfDiscountCalculatorDomainService);
        await orderRepository.Save();
    }

    public async Task Paid(PaidOrderRequestDto dto)
    {
        var order = await orderRepository.GetIncludeItemById(dto.Id);
        if (order is null) throw new ApplicationException("سفارش یافت نشد");
        order.Paid();
        await orderRepository.Save();
    }

    public async Task<Guid> CreateOrder(CreateOrderRequestDto dto)
    {
        var order = dto.Factory();
        await orderRepository.CreateOrder(order);
        await orderRepository.Save();
        return order.Id;
    }

    public async Task AddItemToOrder(AddItemToOrderRequestDto dto)
    {
        var order = await orderRepository.GetIncludeItemById(dto.Id);
        if (order == null) throw new ApplicationException("سفارش یافت نشد");
        order.AddItem(productDomainService, dto.ProductId, dto.Count);
        await orderRepository.Save();
    }
}