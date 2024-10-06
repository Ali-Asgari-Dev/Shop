using Framework.Domain;

namespace Shop.Domain.Models.Categories;

public class Category(string title, int unitOfDiscountForRepurchase) : AggregateRoot<long>
{
    public string Title { get; private set; } = title;
    public int UnitOfDiscountForRepurchase { get; private set; } = unitOfDiscountForRepurchase;
}