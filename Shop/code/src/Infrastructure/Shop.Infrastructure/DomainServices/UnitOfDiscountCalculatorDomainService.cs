using Shop.Domain.Models.Orders;
using Shop.Domain.Services;

namespace Shop.Infrastructure.DomainServices;

public class UnitOfDiscountCalculatorDomainService(IOrderRepository orderRepository) : IUnitOfDiscountCalculatorDomainService
{
    public int Calculate(Guid customerId)
    {
        var lastOrder =  orderRepository.LastOrderByCustomerId(customerId).Result;
        if (lastOrder == null) return 0;
        var result = lastOrder.Items.Sum(i => i.Product.UnitOfDiscountByPrice);
        return result;
    }
}