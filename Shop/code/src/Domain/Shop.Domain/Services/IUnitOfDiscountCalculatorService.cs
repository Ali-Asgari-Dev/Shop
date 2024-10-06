namespace Shop.Domain.Services;

public interface IUnitOfDiscountCalculatorService
{
    int Calculate(Guid customerId);
}