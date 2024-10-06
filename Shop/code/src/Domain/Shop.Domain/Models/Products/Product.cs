using Framework.Domain;

namespace Shop.Domain.Models.Products;

public class Product(long categoryId, string title, string? description, double price):AggregateRoot<long>
{
    public long CategoryId { get;private set; } = categoryId;
    public string Title { get;private set; } = title;
    public string? Description { get;private set; } = description;
    public double Price { get;private set; } = price;
    public int  Inventory { get; set; }
}