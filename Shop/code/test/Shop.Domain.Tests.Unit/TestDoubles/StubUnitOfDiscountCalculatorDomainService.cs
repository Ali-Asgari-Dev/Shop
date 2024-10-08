using Shop.Domain.Services;

namespace Shop.Domain.Tests.Unit.TestDoubles;

public class StubUnitOfDiscountCalculatorDomainService:IUnitOfDiscountCalculatorDomainService
{
    public int Calculate(Guid customerId)
    {
        return 5;
    }
}