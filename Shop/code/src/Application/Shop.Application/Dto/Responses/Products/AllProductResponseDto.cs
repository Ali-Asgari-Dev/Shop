namespace Shop.Application.Dto.Responses.Products;

public class AllProductResponseDto(long id,long categoryId, string title, string? description, double price, int unitOfDiscountByPrice)
{
    public long Id { get;  set; } = id;
    public long CategoryId { get;  set; } = categoryId;
    public string Title { get;  set; } = title;
    public string? Description { get;  set; } = description;
    public double Price { get;  set; } = price;
    public int UnitOfDiscountByPrice { get;  set; } = unitOfDiscountByPrice;
    public int Inventory { get; set; }
}