using Shop.Domain.Models.Categories;

namespace Shop.Domain.Models.Products;

public class ProductFactory
{
    public static Product New(long categoryId, string title, string? description, double price, Category category)
    {
        var unitOfDiscountByPrice = (int)(price / category.UnitOfDiscountForRepurchase);
        return new(categoryId, title, description, price, unitOfDiscountByPrice);
    }
}