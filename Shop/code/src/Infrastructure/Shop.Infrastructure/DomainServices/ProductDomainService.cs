using Shop.Domain.Models.Products;
using Shop.Domain.Services;

namespace Shop.Infrastructure.DomainServices;

public class ProductDomainService(IProductRepository productRepository) : IProductDomainService
{
    public double PriceById(long id) =>productRepository.PriceById(id);
    
}