using Shop.Domain.Services;

namespace Shop.Domain.Tests.Unit.TestDoubles;

public class StubUnitOfDiscountCalculatorService:IUnitOfDiscountCalculatorService
{
    public int Calculate(Guid customerId)
    {
        return 5;
    }
}