namespace Shop.Domain.Services;

public interface IUnitOfDiscountCalculatorDomainService
{
    int Calculate(Guid customerId);
}