namespace Shop.Domain.Models.Categories;

public interface ICategoryRepository
{
    Task<Category?> FindById(long id);
    Task Add(Category category);
    Task<List<Category>> All();
    Task Save();
}