using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Products;

namespace Shop.Infrastructure.Persistence.Sql.Repositories;

public class ProductRepository(DataBaseContext dbContext):IProductRepository
{
    public double PriceById(long id)
        => dbContext.Products.Where(p=>p.Id==id).Select(p=>p.Price).FirstOrDefault();

    public async Task<Product?> FindById(long id)
        => await dbContext.Products.FindAsync(id);

    public async Task Add(Product product)
        => await dbContext.Products.AddAsync(product);
    
    public async Task<List<Product>> All()
        => await dbContext.Products.AsNoTracking().ToListAsync();

    public async Task Save()
        => await dbContext.SaveChangesAsync();
}