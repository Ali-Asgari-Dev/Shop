namespace Shop.Domain.Models.Products;

public interface IProductRepository
{
    double PriceById(long id);
    Task<Product?> FindById(long id);
    Task Add(Product product);
    Task<List<Product>> All();
    Task Save();
}