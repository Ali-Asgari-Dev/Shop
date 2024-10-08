namespace Shop.Domain.Services;

public interface IProductDomainService
{
    double PriceById(long id);
}