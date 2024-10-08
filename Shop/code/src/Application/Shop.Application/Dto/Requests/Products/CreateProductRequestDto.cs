namespace Shop.Application.Dto.Requests.Products;

public class CreateProductRequestDto
{
    public long CategoryId { get;  set; } 
    public string Title { get;  set; } 
    public string? Description { get;  set; }
    public double Price { get;  set; }
    public int Inventory { get; set; }
}