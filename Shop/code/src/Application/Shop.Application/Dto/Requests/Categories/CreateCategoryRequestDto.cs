namespace Shop.Application.Dto.Requests.Categories;

public class CreateCategoryRequestDto
{
    public string Title { get; set; }
    public int UnitOfDiscountForRepurchase { get; set; }
}