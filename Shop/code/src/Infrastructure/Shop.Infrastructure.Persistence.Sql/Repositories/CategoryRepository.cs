using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models.Categories;

namespace Shop.Infrastructure.Persistence.Sql.Repositories;

public class CategoryRepository(DataBaseContext dbContext):ICategoryRepository
{
    public async Task<Category?> FindById(long id)
        => await dbContext.Categories.FindAsync(id);


    public async Task Add(Category category)
        => await dbContext.Categories.AddAsync(category);


    public async Task<List<Category>> All()
        => await dbContext.Categories.AsNoTracking().ToListAsync();
    
    
    public async Task Save()
        => await dbContext.SaveChangesAsync();

}