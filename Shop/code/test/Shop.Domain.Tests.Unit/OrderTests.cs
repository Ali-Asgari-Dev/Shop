using FluentAssertions;
using Framework.Domain;
using Shop.Domain.Models.Orders;
using Shop.Domain.Tests.Unit.TestDoubles;
using Shop.Domain.Tests.Unit.Utils;

namespace Shop.Domain.Tests.Unit;

public class OrderTests
{
    [Fact]
    public void order_apply_discount()
    {
     var   order = OrderTestFactory.NewWithItem();
        order.ApplyDiscount(new StubUnitOfDiscountCalculatorDomainService());
        order.TotalFinalPrice.Should().Be(9500);
    }
    
    [Fact]
    public void order_apply_discount_paid_state_throw_exception()
    {
        var order = OrderTestFactory.NewWithItem();
        order.Paid();
        var act = () => order.ApplyDiscount(new StubUnitOfDiscountCalculatorDomainService());
        act.Should().Throw<BusinessException>();
    }
    
    [Fact]
    public void order_paid_action_should_be_changed_state()
    {
        var   order = OrderTestFactory.NewWithItem();
        order.Paid();
        order.State.Should().Be(OrderState.PaidState());
    }
}